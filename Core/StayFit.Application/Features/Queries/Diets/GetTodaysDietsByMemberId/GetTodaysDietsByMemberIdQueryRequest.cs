using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StayFit.Application.Features.Queries.Diets.GetTodaysDietsByMemberId
{
    public class GetTodaysDietsByMemberIdQueryRequest : IRequest<GetTodaysDietsByMemberIdQueryResponse>
    {
        public Guid MemberId { get; }

        public GetTodaysDietsByMemberIdQueryRequest(Guid memberId)
        {
            MemberId = memberId;
        }
    }
}
