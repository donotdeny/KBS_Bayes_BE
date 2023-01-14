using Core.Models;
using Core.Interfaces.Repository;
using Core.Interfaces.Service;
using System.Linq;
using System.Reflection;

namespace Service.Services
{
    public class TreatmentService : GenericService<Treatment>, ITreatmentService
    {
        private readonly ITreatmentRepository _treatmentRepository;
        private readonly IKBSRepository _kBSRepository;
        public TreatmentService(ITreatmentRepository treatmentRepository, IKBSRepository kBSRepository)
        {
            _treatmentRepository = treatmentRepository;
            _kBSRepository = kBSRepository; 
        }
        public async Task<Treatment> GetAnswer(KBSModel status)
        {
            var listKBS = await _kBSRepository.GetAsync();
            var listTreatment = await _treatmentRepository.GetAsync();
            double maxPossible = 0;
            var res = -1;
            status = HandleMissingData(status);
            foreach (var item in listTreatment)
            {
                double tmp = 1;
                List<KBSModel> list = listKBS.ToList().FindAll(model => model.IdTreatment == item.IdTreatment);
                tmp *= (double) list.FindAll(model => model.Status == status.Status).Count / list.Count;
                tmp *= (double) list.FindAll(model => model.Cooler == status.Cooler).Count / list.Count;
                tmp *= (double) list.FindAll(model => model.Action == status.Action).Count / list.Count;
                tmp *= (double) list.FindAll(model => model.UsageCpu == status.UsageCpu).Count / list.Count;
                tmp *= (double) list.FindAll(model => model.StatusMonitor == status.StatusMonitor).Count / list.Count;
                tmp *= (double) list.FindAll(model => model.LastClean == status.LastClean).Count / list.Count;
                tmp *= (double) list.FindAll(model => model.SignalSata == status.SignalSata).Count / list.Count;
                tmp *= (double) list.FindAll(model => model.Bios == status.Bios).Count / list.Count;
                tmp *= (double) list.FindAll(model => model.BuildPc == status.BuildPc).Count / list.Count;
                tmp *= (double) list.FindAll(model => model.Sound == status.Sound).Count / list.Count;
                if(maxPossible < tmp)
                {
                    maxPossible = tmp;
                    res = item.IdTreatment;
                }
            }
            var answer = await _treatmentRepository.GetByIdAsync(res);
            return answer;
        }

        private KBSModel HandleMissingData(KBSModel status)
        {
            foreach (PropertyInfo prop in status.GetType().GetProperties())
            {
                if (prop.Name != "Id" && prop.Name != "IdTreatment" && prop.Name != "Status" && prop.GetValue(status) == null)
                {
                    switch(prop.Name)
                    {
                        case "Cooler":
                            status.Cooler = "TN-01";
                            break;
                        case "Action":
                            status.Action = "HD-01";
                            break;
                        case "UsageCpu":
                            status.UsageCpu = "US-01";
                            break;
                        case "StatusMonitor":
                            status.StatusMonitor = "MH-01";
                            break;
                        case "LastClean":
                            status.LastClean = "TG-01";
                            break;
                        case "SignalSata":
                            status.SignalSata = "SA-01";
                            break;
                        case "Bios":
                            status.Bios = "HA-01, HA-02, HA-03";
                            break;
                        case "BuildPc":
                            status.BuildPc = "CH-01";
                            break;
                        case "Sound":
                            status.Sound = "AT-01";
                            break;
                    }
                }
            }
            return status;
        }
    }
}
