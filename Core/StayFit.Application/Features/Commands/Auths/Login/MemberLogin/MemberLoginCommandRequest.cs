using MediatR;
using StayFit.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StayFit.Application.Features.Commands.Auths.Login.MemberLogin
{
    public class MemberLoginCommandRequest : IRequest<MemberLoginCommandResponse>
    {
        public LoginDto LoginDto { get; }

        public MemberLoginCommandRequest(LoginDto loginDto)
        {
            LoginDto = loginDto;
        }
    }
}
