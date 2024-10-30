using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StayFit.Application.Features.Commands.Auths.Register.TrainerRegister;
using StayFit.Application.Features.Queries.Trainers.GetAllTrainers;
using StayFit.Application.Features.Queries.Trainers.GetTrainerProfile;
using System.Security.Claims;

namespace StayFit.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TrainersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetTrainerProfile")]
        [Authorize(Roles ="Trainer")]
        public async Task<IActionResult> GetMyProfile()
        {
            string? userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            GetTrainerProfileQueryRequest request = new() { TrainerId = Guid.Parse(userId) };
            GetTrainerProfileQueryResponse response = await _mediator.Send(request);

            return Ok(response.TrainerResponseDto);
        }

        [HttpGet("GetAllTrainersIncludeUser")]
        public async Task<IActionResult> GetAllTrainersIncludeUser()
        {
            GetAllTrainersQueryRequest request = new();
            GetAllTrainersQueryResponse response = await _mediator.Send(request);

            return Ok(response.TrainerResponseDtos);
        }

    }
}
