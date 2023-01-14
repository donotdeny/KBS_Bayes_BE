using Core.Interfaces.Repository;
using Core.Interfaces.Service;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class KBSService : GenericService<KBSModel>, IKBSService
    {
        private readonly IKBSRepository _kbsRepository;
        public KBSService(IKBSRepository kbsRepository)
        {
            _kbsRepository = kbsRepository;
        }
        public async Task<List<string>> GetInfoFromStatus(string status)
        {
            var list = await _kbsRepository.GetByStatusAsync(status);
            var res = new List<string>();
            foreach (var item in list)
            {
                foreach (PropertyInfo prop in item.GetType().GetProperties())
                {
                    if (prop.Name != "Id" && prop.Name != "IdTreatment" && prop.Name != "Status")
                    {
                        string tmpStr = prop.GetValue(item).ToString();
                        if (tmpStr[tmpStr.Length-1] != '1' && !checkExist(res, prop.Name) && tmpStr.Length < 8)
                        {
                            res.Add(prop.Name);
                        }
                    }
                }
            }
            return res;
        }
        private bool checkExist(List<string> res, string tmpStr)
        {
            foreach (var item in res)
            {
                if(item.Equals(tmpStr))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
