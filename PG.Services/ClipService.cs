using Dapper;
using PG.Models;
using PG.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
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

            try
            {
                using (var conn = new SqlConnection(_connectionString.Value))
                {
                    prms.Add("userName", userName, DbType.String);
                    var lookup = new Dictionary<Guid, Clip>();
                    var lookup2 = new Dictionary<Guid, Photo>();
                    conn.Query<Clip, Photo, User, Clip>(
                        sql, 
                        (c, p, u) =>
                        {
                            Clip clip;
                            if (!lookup.TryGetValue(c.Id, out clip))
                            {
                                lookup.Add(c.Id, clip = c);
                            }
                            clip.User = u;
                            Photo photo;
                            if (!lookup2.TryGetValue(p.Id, out photo))
                            {
                                lookup2.Add(p.Id, photo = p);
                                clip.Photos.Add(photo);
                            }
                            return clip;
                        },
                        prms,
                        null,
                        false,
                        "Id",
                        null,
                        CommandType.StoredProcedure).AsQueryable();
                    var response = lookup.Values.ToList();
                    return response;
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
