using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StayFit.Application.DTOs.Exercises;
using StayFit.Application.Features.Commands.Exercises.CreateExercise;
using StayFit.Application.Features.Queries.Exercises.GetExercisesByWorkoutPlanId;

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
        //[Authorize(Roles ="Trainer")]
        public async Task<IActionResult> CreateExercise(CreateExerciseDto createExerciseDto)
        {
            CreateExerciseCommandRequest request = new() { CreateExerciseDto = createExerciseDto };
            CreateExerciseCommandResponse response = await _mediator.Send(request);
            if (response.Success)
                return Ok(response);
            return BadRequest(response);
        }

        [HttpGet("GetExercisesByWorkoutPlanId")]
        public async Task<IActionResult> GetExercisesByWorkoutPlanId(int workoutPlanId)
        {
            GetExercisesByWorkoutPlanIdQueryRequest request = new() { WorkoutPlanId = workoutPlanId };
            GetExercisesByWorkoutPlanIdQueryResponse response = await _mediator.Send(request);
            if (response.Success)
                return Ok(response);
            return BadRequest(response);
        }
    }
}
