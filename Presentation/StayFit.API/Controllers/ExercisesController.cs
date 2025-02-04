using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StayFit.Application.DTOs.Exercises;
using StayFit.Application.Features.Commands.Exercises.CreateExercise;
using StayFit.Application.Features.Commands.Exercises.DeleteExercise;
using StayFit.Application.Features.Queries.Diets.GetTodaysDietsByMemberId;
using StayFit.Application.Features.Queries.Exercises.GetExercisesByWorkoutDayId;
using System.Security.Claims;

namespace StayFit.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExercisesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ExercisesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("CreateExercise")]
        [Authorize(Roles ="Trainer")]
        public async Task<IActionResult> CreateExercise(List<CreateExerciseDto> createExerciseDtos)
        {
            CreateExerciseCommandRequest request = new(createExerciseDtos);
            CreateExerciseCommandResponse response = await _mediator.Send(request);
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpGet("GetExercisesByWorkoutDayId")]
        [Authorize(Roles ="Trainer, Member")]
        public async Task<IActionResult> GetExercisesByWorkoutDayId(int workoutDayId)
        {
            GetExercisesByWorkoutDayIdQueryRequest request = new(workoutDayId);
            GetExercisesByWorkoutDayIdQueryResponse response = await _mediator.Send(request);
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpDelete("DeleteExercise")]
        [Authorize(Roles ="Trainer")]
        public async Task<IActionResult> DeleteExercise(int excersiceId)
        {
            var request = new DeleteExerciseCommandRequest(excersiceId);
            var response = await _mediator.Send(request);

            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpGet("[action]")]
        [Authorize(Roles ="Member")]
        public async Task<IActionResult> GetTodaysExercises()
        {
            string? memberId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var request = new GetTodaysDietsByMemberIdQueryRequest(Guid.Parse(memberId));
            var response = await _mediator.Send(request);

            return response.Success ? Ok(response) : NotFound(response);
        }
    }
}
