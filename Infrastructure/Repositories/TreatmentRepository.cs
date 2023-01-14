using Core.Interfaces.Repository;
using Core.Models;
using MySqlConnector;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class TreatmentRepository : GenericRepository<Treatment>, ITreatmentRepository
    {
        public override async Task<IEnumerable<Treatment>> GetAsync()
        {
            try
            {
                using (mySqlConnection = new MySqlConnection(connectionString))
                {
                    var sqlQuery = "Select * from treatment";
                    var listResult = await mySqlConnection.QueryAsync<Treatment>(sqlQuery);
                    return listResult;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
