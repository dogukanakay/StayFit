using MediatR;
using StayFit.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StayFit.Application.Features.Commands.Auths.Login.TrainerLogin
{
    public class TrainerLoginCommandRequest : IRequest<TrainerLoginCommandResponse>
    {
        public LoginDto LoginDto { get; }

        public TrainerLoginCommandRequest(LoginDto loginDto)
        {
            LoginDto = loginDto;
        }
    }
}
