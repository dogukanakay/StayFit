using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StayFit.Application.Features.Queries.WeeklyProgresses.GetWeeklyProgressesBySubsId
{
    public class GetWeeklyProgressesBySubsIdQueryRequest : IRequest<GetWeeklyProgressesBySubsIdQueryResponse>
    {
        public  Guid SubscriptionId { get; }

        public GetWeeklyProgressesBySubsIdQueryRequest(Guid subscriptionId)
        {
            SubscriptionId = subscriptionId;
        }
    }  
}
