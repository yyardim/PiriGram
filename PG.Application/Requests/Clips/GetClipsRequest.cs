using MediatR;
using PG.Application.Responses.Clips;

namespace PG.Application.Requests.Clips
{
    public class GetClipsRequest : IRequest<GetClipsResponse>
    {
        public string UserName { get; set; }
        public GetClipsRequest(string userName)
        {
            UserName = userName;
        }
    }
}
