using MediatR;
using StayFit.Application.DTOs.Videos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StayFit.Application.Features.Commands.Videos.CreateVideo
{
    public class CreateVideoCommandRequest : IRequest<CreateVideoCommandResponse>
    {
        public CreateVideoDto CreateVideoDto { get; }

        public CreateVideoCommandRequest(CreateVideoDto createVideoDto)
        {
            CreateVideoDto = createVideoDto;
        }
    }
}
