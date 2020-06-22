using PG.Models;
using System;
using System.Threading.Tasks;

namespace PG.Services.Contracts
{
    public interface IPhotoService
    {
        Task<Photo> GetPhotoById(Guid Id);
    }
}
