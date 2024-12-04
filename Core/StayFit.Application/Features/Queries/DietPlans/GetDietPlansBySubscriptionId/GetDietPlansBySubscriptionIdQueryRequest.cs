using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StayFit.Application.Features.Queries.DietPlans.GetDietPlansBySubscriptionId
{
    public class GetDietPlansBySubscriptionIdQueryRequest :IRequest<GetDietPlansBySubscriptionIdQueryResponse>
    {
        public Guid SubscriptionId { get;}

        public GetDietPlansBySubscriptionIdQueryRequest(Guid subscriptionId)
        {
            SubscriptionId = subscriptionId;
        }
    }
}
