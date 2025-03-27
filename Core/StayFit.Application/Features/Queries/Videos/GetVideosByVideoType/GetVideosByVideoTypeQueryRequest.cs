using MediatR;
using StayFit.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StayFit.Application.Features.Queries.Videos.GetVideosByVideoType
{
    public class GetVideosByVideoTypeQueryRequest : IRequest<GetVideosByVideoTypeQueryResponse>
    {
        public VideoTypes VideoType { get;}

        public GetVideosByVideoTypeQueryRequest(VideoTypes videoType)
        {
            VideoType = videoType;
        }
    }
}
