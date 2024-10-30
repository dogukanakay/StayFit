using MediatR;
using StayFit.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StayFit.Application.Features.Commands.Subscriptions.CreateSubscription
{
    public class CreateSubscriptionCommandRequest : IRequest<CreateSubscriptionCommandResponse>
    {
        public CreateSubscriptionDto CreateSubscriptionDto { get; set; }
    }
}
