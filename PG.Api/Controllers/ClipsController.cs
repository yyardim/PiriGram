using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using PG.Application.Requests.Clips;
using PG.Models;

namespace PG.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClipsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ClipsController(
            IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<Clip>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Get(String userName)
        {
            var clips = await _mediator.Send(new GetClipsRequest(userName));

            return Ok(clips);
        }
    }
}
