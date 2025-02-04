using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StayFit.Application.DTOs.WorkoutPlans;
using StayFit.Application.Features.Commands.WorkoutPlans.CreateWorkoutPlan;
using StayFit.Application.Features.Commands.WorkoutPlans.DeleteWorkoutPlan;
using StayFit.Application.Features.Commands.WorkoutPlans.UpdateWorkoutPlan;
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
            CreateWorkoutPlanCommandRequest request = new(createWorkoutPlanDto);
            var response = await _mediator.Send(request);
            return response.Success ? Ok(response) : BadRequest(response); ;
        }

        [HttpGet("GetWorkoutPlansByMemberId")]
        [Authorize(Roles = "Member")]
        public async Task<IActionResult> GetWorkoutPlansByMemberId()
        {
            var memberId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            GetWorkoutPlansByMemberIdQueryRequest request = new(Guid.Parse(memberId));
            var response = await _mediator.Send(request);
            return response.Success ? Ok(response) : BadRequest(response);

        }

        [HttpGet("GetWorkoutPlansBySubscriptionId")]
        [Authorize(Roles = "Trainer")]
        public async Task<IActionResult> GetWorkoutPlansBySubscriptionId(string subscriptionId)
        {
            GetWorkoutPlansBySubscriptionIdQueryRequest request = new(Guid.Parse(subscriptionId));
            var response = await _mediator.Send(request);
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpDelete("DeleteWorkoutPlanById/{id}")]
        [Authorize(Roles = "Trainer")]
        public async Task<IActionResult> DeleteWorkoutPlanById(int id)
        {
            DeleteWorkoutPlanCommandRequest request = new(id);
            var response = await _mediator.Send(request);
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpPut("UpdateWorkoutPlan")]
        [Authorize(Roles = "Trainer")]
        public async Task<IActionResult> UpdateWorkoutPlan(UpdateWorkoutPlanDto updateWorkoutPlanDto)
        {
            UpdateWorkoutPlanCommandRequest request = new(updateWorkoutPlanDto);
            var response = await _mediator.Send(request);

            return response.Success ? Ok(response) : BadRequest(response);
        }

    }
}
