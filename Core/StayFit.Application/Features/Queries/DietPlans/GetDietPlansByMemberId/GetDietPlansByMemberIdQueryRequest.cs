using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StayFit.Application.Features.Queries.DietPlans.GetDietPlansByMemberId
{
    public class GetDietPlansByMemberIdQueryRequest : IRequest<GetDietPlansByMemberIdQueryResponse>
    {
        public Guid MemberId { get; }

        public GetDietPlansByMemberIdQueryRequest(Guid memberId)
        {
            MemberId = memberId;
        }
    }
}
