using Core.Interfaces.Repository;
using Core.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class GenericService<Entity> : IGenericService<Entity> where Entity : class
    {
       
    }
}
