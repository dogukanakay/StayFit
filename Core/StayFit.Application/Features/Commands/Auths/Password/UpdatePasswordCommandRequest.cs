using MediatR;
using StayFit.Application.DTOs.Auths;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StayFit.Application.Features.Commands.Auths.Password
{
    public class UpdatePasswordCommandRequest : IRequest<UpdatePasswordCommandResponse>
    {
        public UpdatePasswordDto UpdatePasswordDto { get;}
        public Guid UserId { get;}

        public UpdatePasswordCommandRequest(UpdatePasswordDto updatePasswordDto, Guid userId)
        {
            UpdatePasswordDto = updatePasswordDto;
            UserId = userId;
        }
    }
}
