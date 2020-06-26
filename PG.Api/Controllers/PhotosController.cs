using System;
using System.Net;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using PG.Application.Requests.Photos;
using PG.Models;

namespace PG.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhotosController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PhotosController(
            IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(typeof(Photo), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Get(Guid Id)
        {
            var photo = await _mediator.Send(new GetPhotoRequest(Id));

            return Ok(photo);
        }
    }
}
