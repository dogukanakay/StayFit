using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StayFit.Application.DTOs;
using StayFit.Application.Features.Commands.Subscriptions.CreateSubscription;
using StayFit.Application.Features.Queries.Members.GetMemberProfile;
using StayFit.Application.Features.Queries.Subscriptions.GetMemberSubscribedTrainer;
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
        [Authorize(Roles ="Member")]
        public async Task<IActionResult> CreateSubscription(string trainerId, string? goal)
        {
            var memberId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            CreateSubscriptionDto createSubscriptionDto = new()
            {
                MemberId = Guid.Parse(memberId),
                TrainerId = Guid.Parse(trainerId),
                Goal = goal
            };
            CreateSubscriptionCommandRequest request = new() { CreateSubscriptionDto = createSubscriptionDto};
            CreateSubscriptionCommandResponse response = await _mediator.Send(request);

            return Ok(response);
        }

        [HttpGet("GetTrainerSubscribers")]
        [Authorize(Roles ="Trainer")]
        public async Task<IActionResult> GetTrainerSubscribers()
        {
            var trainerId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            GetTrainerSubscribersQueryRequest request = new() { TrainerId = Guid.Parse(trainerId) };
            GetTrainerSubscribersQueryResponse response = await _mediator.Send(request);

            return Ok(response.GetTrainerSubscribersDtos);
        }

        [HttpGet("GetMemberSubscribedTrainer")]
        [Authorize(Roles ="Member")]
        public async Task<IActionResult> GetMemberSubscribedTrainer()
        {
            var memberId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            GetMemberSubscribedTrainerQueryRequest request = new() { MemberId = Guid.Parse(memberId) };
            GetMemberSubscribedTrainerQueryResponse response = await _mediator.Send(request);

            return Ok(response.GetMemberSubscribedTrainerDto);
        }
    }
}
