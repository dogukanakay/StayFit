using MediatR;
using StayFit.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StayFit.Application.Features.Commands.Auths.Login
{
    public class LoginCommandRequest : IRequest<LoginCommandResponse>
    {
        public DTOs.LoginDto LoginModel { get; set; }
    }
}
