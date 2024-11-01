using MediatR;
using StayFit.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StayFit.Application.Features.Queries.Subscriptions.GetMemberSubscribedTrainer
{
    public class GetMemberSubscribedTrainerQueryRequest : IRequest<GetMemberSubscribedTrainerQueryResponse>
    {
        public Guid MemberId { get; set; }
    }
}
