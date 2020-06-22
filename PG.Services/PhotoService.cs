using Dapper;
using PG.Models;
using PG.Services.Contracts;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace PG.Services
{
    public class PhotoService : IPhotoService
    {
        private readonly ConnectionString _connectionString;
        public PhotoService(ConnectionString connectionString)
        {
            _connectionString = connectionString;
        }
        public async Task<Photo> GetPhotoById(Guid Id)
        {
            var sql = "sp_Photo_GetById";
            var p = new DynamicParameters();
            p.Add("Id", Id, DbType.Guid);

            try
            {
                using (var conn = new SqlConnection(_connectionString.Value))
                {
                    var response = await conn.QueryAsync<Photo>(
                        sql: sql,
                        param: p,
                        commandType: CommandType.StoredProcedure);
                    return response.FirstOrDefault();
                }
            }
            catch (TimeoutException ex)
            {
                throw new Exception($"Sql timeout in {sql} call - ", ex);
            }
            catch (SqlException ex)
            {
                throw new Exception($"Sql exception in {sql} call - ", ex);
            }
        }
    }
}
