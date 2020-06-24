using PG.Models;
using System.Collections.Generic;

namespace PG.Application.Responses.Clips
{
    public class GetClipsResponse
    {
        public List<Clip> Clips { get; set; }
    }
}
