using Dapper;
using Newtonsoft.Json;
using PG.Models;
using PG.Services.Contracts;
using PG.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
            var parameters = new DynamicParameters();
            List<Clip> result = new List<Clip>();
            try
            {
                using (var conn = new SqlConnection(_connectionString.Value))
                {
                    parameters.Add("userName", userName, DbType.String);
                    var response = await conn.QueryAsync<string>(
                        sql: sql,
                        param: parameters,
                        commandType: CommandType.StoredProcedure
                    );

                    // Join possible multi rowset
                    var responseMerged = string.Join("", response);
                    if (responseMerged != null)
                    {
                        result = JsonConvert.DeserializeObject<List<Clip>>(StringHelper.JsonForDeserialize(responseMerged));
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
