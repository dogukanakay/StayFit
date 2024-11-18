using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StayFit.Application.DTOs.Exercises;
using StayFit.Application.Features.Commands.Exercises.CreateExercise;

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
        public async Task<IActionResult> CreateExercise(CreateExerciseDto createExerciseDto)
        {
            CreateExerciseCommandRequest request = new() { CreateExerciseDto = createExerciseDto };
            CreateExerciseCommandResponse response = await _mediator.Send(request);
            if(response.Success)
                return Ok(response);
            return BadRequest(response);
        }
    }
}
