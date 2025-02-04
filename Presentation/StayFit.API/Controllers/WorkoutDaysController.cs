using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StayFit.Application.DTOs.WorkoutDays;
using StayFit.Application.Features.Commands.WorkoutDays.CreateWorkoutDay;
using StayFit.Application.Features.Commands.WorkoutDays.DeleteWorkoutDay;
using StayFit.Application.Features.Commands.WorkoutDays.UpdateWorkoutDayCompleted;
using StayFit.Application.Features.Queries.WorkoutDays.GetWorkoutDaysByWorkoutPlanId;
using System.Security.Claims;

namespace StayFit.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkoutDaysController : ControllerBase
    {
        private readonly IMediator _mediator;

        public WorkoutDaysController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("CreateWorkoutDay")]
        [Authorize(Roles = "Trainer")]
        public async Task<IActionResult> CreateWorkoutDay(CreateWorkoutDayDto createWorkoutDayDto)
        {
            CreateWorkoutDayCommandRequest request = new(createWorkoutDayDto);
            var response = await _mediator.Send(request);
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpGet("GetWorkoutDaysByWorkoutPlanId")]
        [Authorize (Roles ="Trainer, Member")]
        public async Task<IActionResult> GetWorkoutDaysByWorkoutPlanId(int workoutPlanId)
        {
            GetWorkoutDaysByWorkoutPlanIdQueryRequest request = new(workoutPlanId);
            var response = await _mediator.Send(request);
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpDelete("DeleteWorkoutDay/{workoutDayId}")]
        [Authorize (Roles = "Trainer")]
        public async Task<IActionResult> DeleteWorkoutDay(int workoutDayId)
        {
            DeleteWorkoutDayCommandRequest request = new(workoutDayId);
            DeleteWorkoutDayCommandResponse response = await _mediator.Send(request);

            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpPut("[action]")]
        [Authorize(Roles = "Member")]
        public async Task<IActionResult> WorkoutDayCompleted(int workoutDayId)
        {
            string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var request = new UpdateWorkoutDayCompletedCommandRequest(Guid.Parse(userId), workoutDayId);
            var response = await _mediator.Send(request);

            return response.Success ? Ok(response) : BadRequest(response);
        }
    }
}
