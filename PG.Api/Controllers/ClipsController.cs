using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PG.Models;
using PG.Services.Contracts;

namespace PG.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClipsController : ControllerBase
    {
        private readonly ConnectionString _connectionString;
        private readonly IClipService _clipService;
        public ClipsController(
            ConnectionString connectionString,
            IClipService clipService)
        {
            _connectionString = connectionString;
            _clipService = clipService;
        }

        [HttpGet]
        public async Task<List<Clip>> Get(String userName)
        {
            return await _clipService.GetClipsbyUserName(userName);
        }
    }
}
