using PG.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PG.Services.Contracts
{
    public interface IClipService
    {
        Task<List<Clip>> GetClipsbyUserName(String userName);
    }
}
