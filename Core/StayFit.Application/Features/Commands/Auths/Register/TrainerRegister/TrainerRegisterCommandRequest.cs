using MediatR;
using StayFit.Application.DTOs;

namespace StayFit.Application.Features.Commands.Auths.Register.TrainerRegister
{
    public class TrainerRegisterCommandRequest : IRequest<TrainerRegisterCommandResponse>
    {
        public TrainerRegisterDto TrainerRegisterDto { get; }

        public TrainerRegisterCommandRequest(TrainerRegisterDto trainerRegisterDto)
        {
            TrainerRegisterDto = trainerRegisterDto;
        }
    } 

}
