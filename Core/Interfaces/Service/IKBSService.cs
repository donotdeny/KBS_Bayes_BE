using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.Service
{
    public interface IKBSService : IGenericService<KBSModel>
    {
        Task<List<string>> GetInfoFromStatus(string status);
    }
}
