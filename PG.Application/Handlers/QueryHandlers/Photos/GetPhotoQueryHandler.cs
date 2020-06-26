using MediatR;
using PG.Application.Requests.Photos;
using PG.Application.Responses.Photos;
using PG.Services.Contracts;
using System.Threading;
using System.Threading.Tasks;

namespace PG.Application.Handlers.QueryHandlers.Photos
{
    public class GetPhotoQueryHandler : IRequestHandler<GetPhotoRequest, GetPhotoResponse>
    {
        private readonly IPhotoService _service;
        public GetPhotoQueryHandler(IPhotoService service)
        {
            _service = service;
        }
        public async Task<GetPhotoResponse> Handle(GetPhotoRequest request, CancellationToken cancellationToken)
        {
            var response = new GetPhotoResponse
            {
                Photo = await _service.GetPhotoById(request.Id)
            };

            return response;
        }
    }
}
