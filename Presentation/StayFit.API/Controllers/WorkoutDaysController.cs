using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StayFit.Application.DTOs.WorkoutDays;
using StayFit.Application.Features.Commands.WorkoutDays.CreateWorkoutDay;
using StayFit.Application.Features.Commands.WorkoutDays.DeleteWorkoutDay;
using StayFit.Application.Features.Queries.WorkoutDays.GetWorkoutDaysByWorkoutPlanId;

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
       // [Authorize(Roles = "Trainer")]
        public async Task<IActionResult> CreateWorkoutDay(CreateWorkoutDayDto createWorkoutDayDto)
        {
            CreateWorkoutDayCommandRequest request = new() { CreateWorkoutDayDto = createWorkoutDayDto };
            CreateWorkoutDayCommandResponse response = await _mediator.Send(request);
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpGet("GetWorkoutDaysByWorkoutPlanId")]
        [Authorize]
        public async Task<IActionResult> GetWorkoutDaysByWorkoutPlanId(int workoutPlanId)
        {
            GetWorkoutDaysByWorkoutPlanIdQueryRequest request = new() { WorkoutPlanId = workoutPlanId };
            GetWorkoutDaysByWorkoutPlanIdQueryResponse response = await _mediator.Send(request);
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpDelete("DeleteWorkoutDay/{workoutDayId}")]
        public async Task<IActionResult> DeleteWorkoutDay(int workoutDayId)
        {
            DeleteWorkoutDayCommandRequest request = new() { WorkoutDayId = workoutDayId };
            DeleteWorkoutDayCommandResponse response = await _mediator.Send(request);

            return response.Success ? Ok(response) : BadRequest(response);
        }
    }
}
