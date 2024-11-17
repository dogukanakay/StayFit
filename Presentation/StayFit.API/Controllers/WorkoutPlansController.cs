using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StayFit.Application.DTOs.WorkoutPlans;
using StayFit.Application.Features.Commands.WorkoutPlans.CreateWorkoutPlan;
using StayFit.Application.Features.Queries.WorkoutPlans.GetWorkoutPlansByMemberId;
using StayFit.Application.Features.Queries.WorkoutPlans.GetWorkoutPlansBySubscriptionId;
using System.Security.Claims;

namespace StayFit.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkoutPlansController : ControllerBase
    {
        private readonly IMediator _mediator;

        public WorkoutPlansController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("CreateWorkoutPlan")]
        [Authorize(Roles = "Trainer")]
        public async Task<IActionResult> CreateWorkoutPlan(CreateWorkoutPlanDto createWorkoutPlanDto)
        {
            CreateWorkoutPlanCommandRequest request = new() { CreateWorkoutPlanDto = createWorkoutPlanDto };
            CreateWorkoutPlanCommandResponse response = await _mediator.Send(request);
            if (response.Success)
                return Ok(response);
            return BadRequest(response);
        }

        [HttpGet("GetWorkoutPlansByMemberId")]
        [Authorize(Roles = "Member")]
        public async Task<IActionResult> GetWorkoutPlansByMemberId()
        {
            var memberId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            GetWorkoutPlansByMemberIdQueryRequest request = new() { MemberId = Guid.Parse(memberId) };
            GetWorkoutPlansByMemberIdQueryResponse response = await _mediator.Send(request);
            if (response.Success)
                return Ok(response);
            return BadRequest(response);

        }

        [HttpGet("GetWorkoutPlansBySubscriptionId")]
       // [Authorize(Roles = "Trainer")]
        public async Task<IActionResult> GetWorkoutPlansBySubscriptionId(Guid subscriptionId)
        {
            GetWorkoutPlansBySubscriptionIdQueryRequest request = new() { SubscriptionId = subscriptionId };
            GetWorkoutPlansBySubscriptionIdQueryResponse response = await _mediator.Send(request);
            if(response.Success)
                return Ok(response);
            return BadRequest(response);
        }
    }
}
