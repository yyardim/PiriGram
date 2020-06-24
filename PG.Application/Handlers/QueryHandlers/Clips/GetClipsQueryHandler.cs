using MediatR;
using PG.Application.Requests.Clips;
using PG.Application.Responses.Clips;
using PG.Services.Contracts;
using System.Threading;
using System.Threading.Tasks;

namespace PG.Application.Handlers.QueryHandlers.Clips
{
    public class GetClipsQueryHandler : IRequestHandler<GetClipsRequest, GetClipsResponse>
    {
        private readonly IClipService _service;
        public GetClipsQueryHandler(IClipService service)
        {
            _service = service;
        }
        public async Task<GetClipsResponse> Handle(GetClipsRequest request, CancellationToken cancellationToken)
        {
            var response = new GetClipsResponse
            {
                Clips = await _service.GetClipsbyUserName(request.UserName)
            };

            return response;
        }
    }
}
