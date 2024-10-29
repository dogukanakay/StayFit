using MediatR;
using StayFit.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StayFit.Application.Features.Commands.Auths.Register.MemberRegister
{
    public class MemberRegisterCommandRequest : IRequest<MemberRegisterCommandResponse>
    {
        public MemberRegisterDto MemberRegisterDto { get; set; }
    }
}
