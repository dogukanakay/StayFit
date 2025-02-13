using MediatR;
using StayFit.Application.DTOs.Members;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StayFit.Application.Features.Commands.Members.UpdateMember
{
    public class UpdateMemberCommandRequest : IRequest<UpdateMemberCommandResponse>
    {
        public UpdateMemberDto UpdateMemberDto { get;}
        public Guid MemberId { get; init; }

        public UpdateMemberCommandRequest(UpdateMemberDto updateMemberDto, Guid memberId)
        {
            UpdateMemberDto = updateMemberDto;
            MemberId = memberId;
        }
    }
}
