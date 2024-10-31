using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StayFit.Application.Features.Queries.Subscriptions.GetTrainerSubscribers
{
    public class GetTrainerSubscribersQueryRequest : IRequest<GetTrainerSubscribersQueryResponse>
    {
        public Guid TrainerId { get; set; }
    }
}
