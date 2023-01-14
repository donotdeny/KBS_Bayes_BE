using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.Service
{
    public interface ITreatmentService : IGenericService<Treatment>
    {
        Task<Treatment> GetAnswer(KBSModel status);
    }
}
