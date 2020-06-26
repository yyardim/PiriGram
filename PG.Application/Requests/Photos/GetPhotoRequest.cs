using MediatR;
using PG.Application.Responses.Photos;
using System;

namespace PG.Application.Requests.Photos
{
    public class GetPhotoRequest : IRequest<GetPhotoResponse>
    {
        public Guid Id { get; set; }
        public GetPhotoRequest(Guid id)
        {
            Id = id;
        }
    }
}
