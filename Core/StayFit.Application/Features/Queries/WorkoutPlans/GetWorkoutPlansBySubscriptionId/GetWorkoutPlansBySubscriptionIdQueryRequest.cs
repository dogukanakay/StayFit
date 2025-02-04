using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StayFit.Application.Features.Queries.WorkoutPlans.GetWorkoutPlansBySubscriptionId
{
    public class GetWorkoutPlansBySubscriptionIdQueryRequest : IRequest<GetWorkoutPlansBySubscriptionIdQueryResponse>
    {
        public Guid SubscriptionId { get; }

        public GetWorkoutPlansBySubscriptionIdQueryRequest(Guid subscriptionId)
        {
            SubscriptionId = subscriptionId;
        }
    }
}
