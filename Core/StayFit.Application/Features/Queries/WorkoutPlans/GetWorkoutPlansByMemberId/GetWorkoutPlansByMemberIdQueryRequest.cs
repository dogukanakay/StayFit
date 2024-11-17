using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StayFit.Application.Features.Queries.WorkoutPlans.GetWorkoutPlansByMemberId
{
    public class GetWorkoutPlansByMemberIdQueryRequest : IRequest<GetWorkoutPlansByMemberIdQueryResponse>
    {
        public Guid MemberId { get; set; }
    }
}
