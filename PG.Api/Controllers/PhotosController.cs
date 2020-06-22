using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PG.Models;
using PG.Services.Contracts;

namespace PG.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhotosController : ControllerBase
    {
        private readonly ILogger<PhotosController> _logger;
        private readonly IPhotoService _photoService;

        public PhotosController(
            ILogger<PhotosController> logger,
            IPhotoService photoService)
        {
            _logger = logger;
            _photoService = photoService;
        }

        [HttpGet]
        public async Task<Photo> Get(Guid Id)
        {
            return await _photoService.GetPhotoById(Id);
        }
    }
}
