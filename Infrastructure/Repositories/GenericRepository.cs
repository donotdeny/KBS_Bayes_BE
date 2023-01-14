using Core.Interfaces.Repository;
using Dapper;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class GenericRepository<Entity> : IGenericRepository<Entity> where Entity : class
    {
        protected string connectionString;
        protected MySqlConnection mySqlConnection;
        public GenericRepository()
        {
            connectionString = "Host = localhost;Port = 3306;Database = chtdttt;User Id = root;Password = ghijkl121";
        }
    
        public virtual async Task<IEnumerable<Entity>> GetAsync()
        {
            try
            {
                using (mySqlConnection = new MySqlConnection(connectionString))
                {
                    var sqlQuery = "Select * from computer_knowledge";
                    var listResult = await mySqlConnection.QueryAsync<Entity>(sqlQuery);
                    return listResult;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Entity> GetByIdAsync(int id)
        {
            try
            {
                using (mySqlConnection = new MySqlConnection(connectionString))
                {
                    var sqlQuery = "Select * from treatment where idTreatment=" + id;
                    var res = await mySqlConnection.QueryFirstOrDefaultAsync<Entity>(sqlQuery);
                    return res;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<Entity>> GetByStatusAsync(string status)
        {
            try
            {
                using (mySqlConnection = new MySqlConnection(connectionString))
                {
                    var sqlQuery = $"Select * from computer_knowledge where status='{status}'";
                    var listResult = await mySqlConnection.QueryAsync<Entity>(sqlQuery);
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
