using Dapper;
using Newtonsoft.Json;
using PG.Models;
using PG.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace PG.Services
{
    public class ClipService : IClipService
    {
        private readonly ConnectionString _connectionString;
        public ClipService(ConnectionString connectionString)
        {
            _connectionString = connectionString;
        }
        public async Task<List<Clip>> GetClipsbyUserName(String userName)
        {
            var sql = "sp_Clips_GetByUserName";
            var prms = new DynamicParameters();
            List<Clip> result = new List<Clip>();
            try
            {
                using (var conn = new SqlConnection(_connectionString.Value))
                {
                    prms.Add("userName", userName, DbType.String);
                    var response = await conn.ExecuteScalarAsync<string>(
                        sql: sql,
                        param: prms,
                        commandType: CommandType.StoredProcedure
                    );

                    if (response != null)
                    {
                        result = JsonConvert.DeserializeObject<List<Clip>>(response);
                    }
                    return result;
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
