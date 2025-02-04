using MediatR;
using StayFit.Application.DTOs.Trainers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StayFit.Application.Features.Commands.Trainers.UpdateTrainer
{
    public class UpdateTrainerCommandRequest : IRequest<UpdateTrainerCommandResponse>
    {
        public UpdateTrainerDto UpdateTrainerDto { get; }

        public UpdateTrainerCommandRequest(UpdateTrainerDto updateTrainerDto)
        {
            UpdateTrainerDto = updateTrainerDto;
        }
    }
}
