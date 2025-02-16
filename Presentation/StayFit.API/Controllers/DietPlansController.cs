using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StayFit.Application.Constants.Messages;
using StayFit.Application.DTOs.DietPlans;
using StayFit.Application.Features.Commands.DietPlans.CreateDietPlan;
using StayFit.Application.Features.Commands.DietPlans.DeleteDietPlan;
using StayFit.Application.Features.Queries.DietPlans.GetDietPlansByMemberId;
using StayFit.Application.Features.Queries.DietPlans.GetDietPlansBySubscriptionId;
using System.Security.Claims;

namespace StayFit.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DietPlansController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DietPlansController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("CreateDietPlan")]
        [Authorize(Roles = "Trainer")]
        public async Task<IActionResult> CreateDietPlan(CreateDietPlanDto createDietPlanDto)
        {
            var trainerId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            CreateDietPlanCommandRequest request = new(createDietPlanDto, Guid.Parse(trainerId));
            CreateDietPlanCommandResponse response = await _mediator.Send(request);

            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpGet("[action]")]
        [Authorize(Roles = "Trainer, Member")]
        public async Task<IActionResult> GetDietPlansBySubscriptionId(string subscriptionId)
        {
            if (!Guid.TryParse(subscriptionId, out var subscriptionIdGuid))
                return BadRequest(Messages.SubscriptionIdWrong);

            var request = new GetDietPlansBySubscriptionIdQueryRequest(subscriptionIdGuid);
            var response = await _mediator.Send(request);

            return response.Success ? Ok(response) : NotFound(response);
        }

        [HttpGet("[action]")]
        [Authorize(Roles ="Member")]
        public async Task<IActionResult> GetDietPlansByMemberId()
        {
            var memberId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var request = new GetDietPlansByMemberIdQueryRequest(Guid.Parse(memberId));
            var response = await _mediator.Send(request);

            return response.Success ? Ok(response) : NotFound(response);
        }

        [HttpDelete("[action]")]
        [Authorize(Roles = "Trainer")]
        public async Task<IActionResult> DeleteDietPlan(int dietPlanId)
        {
            var trainerId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var request = new DeleteDietPlanCommandRequest(dietPlanId, Guid.Parse(trainerId));
            var response = await _mediator.Send(request);

            return response.Success ? Ok(response) : NotFound(response);

        }
    }
}
