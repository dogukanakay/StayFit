using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StayFit.Application.DTOs;
using StayFit.Application.Features.Commands.Subscriptions.CreateSubscription;
using StayFit.Application.Features.Queries.Subscriptions.GetTrainerSubscribers;
using StayFit.Domain.Enums;
using System.Security.Claims;

namespace StayFit.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscriptionsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SubscriptionsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("CreateSubscription")]
        //[Authorize(Roles ="Member")]
        public async Task<IActionResult> CreateSubscription(string trainerId)
        {
            var memberId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            CreateSubscriptionDto createSubscriptionDto = new()
            {
                MemberId = Guid.Parse(memberId),
                TrainerId = Guid.Parse(trainerId),
            };
            CreateSubscriptionCommandRequest request = new() { CreateSubscriptionDto = createSubscriptionDto};
            CreateSubscriptionCommandResponse response = await _mediator.Send(request);

            return Ok(response);
        }

        [HttpGet("GetTrainerSubscribers")]
        public async Task<IActionResult> GetTrainerSubscribers()
        {
            var trainerId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            GetTrainerSubscribersQueryRequest request = new() { TrainerId = Guid.Parse(trainerId) };
            GetTrainerSubscribersQueryResponse response = await _mediator.Send(request);

            return Ok(response.GetTrainerSubscribersDtos);
        }
    }
}
