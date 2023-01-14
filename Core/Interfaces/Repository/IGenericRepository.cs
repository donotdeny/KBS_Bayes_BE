using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.Repository
{
    public interface IGenericRepository<Entity>
    {
        Task<IEnumerable<Entity>> GetAsync();
        Task<Entity> GetByIdAsync(int id);

        Task<IEnumerable<Entity>> GetByStatusAsync(string status);    
    }
}
