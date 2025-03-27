using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StayFit.Application.Features.Commands.Videos.DeleteVideo
{
    public class DeleteVideoCommandRequest : IRequest<DeleteVideoCommandResponse>
    {
        public int VideoId { get; }

        public DeleteVideoCommandRequest(int videoId)
        {
            VideoId = videoId;
        }
    }
}
