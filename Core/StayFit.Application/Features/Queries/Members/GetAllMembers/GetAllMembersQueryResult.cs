using StayFit.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StayFit.Application.Features.Queries.Members.GetAllMembers
{
    public class GetAllMembersQueryResult
    {
        public List<MemberResponseDto> MemberResponseDtos { get; }

        public GetAllMembersQueryResult(List<MemberResponseDto> memberResponseDtos)
        {
            MemberResponseDtos = memberResponseDtos;
        }
    }
}
