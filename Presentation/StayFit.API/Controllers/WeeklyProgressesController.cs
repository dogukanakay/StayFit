using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StayFit.Application.DTOs.WeeklyProgresses;
using StayFit.Application.Features.Commands.WeeklyProgresses.CreateWeeklyProgress;
using StayFit.Application.Features.Commands.WeeklyProgresses.CreateWeeklyProgressByAI;
using StayFit.Application.Features.Queries.WeeklyProgresses.GetWeeklyProgressesBySubsId;
using StayFit.Domain.Entities;
using System.Security.Claims;

namespace StayFit.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeeklyProgressesController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IMediator _mediator;

        public WeeklyProgressesController(IConfiguration configuration, IMediator mediator)
        {
            _configuration = configuration;
            _mediator = mediator;
        }

        [HttpPost("CreateWeeklyProgressByAI")]
        [Authorize(Roles = "Member")]
        public async Task<IActionResult> CreateWeeklyProgressByAI([FromForm] CreateWeeklyProgressByAIDto createWeeklyProgressByAIDto, [FromForm] IFormFileCollection files)
        {
            string? userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var request = new CreateWeeklyProgressByAICommandRequest(
                createWeeklyProgressByAIDto,
                files,
                _configuration["BaseStorageUrl"],
                Guid.Parse(userId)
                );

            CreateWeeklyProgressByAICommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("CreateWeeklyProgress")]
        [Authorize(Roles = "Member")]
        public async Task<IActionResult> CreateWeeklyProgress([FromForm] CreateWeeklyProgressDto createWeeklyProgressDto, [FromForm] IFormFileCollection files)
        {
            string? userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var request = new CreateWeeklyProgressCommandRequest(
                files,
                createWeeklyProgressDto,
                _configuration["BaseStorageUrl"],
                Guid.Parse(userId)
                );


            var response = await _mediator.Send(request);

            return response.Success ? Ok(response) : BadRequest(response);
        }



        [HttpGet("GetWeeklyProgressesBySubsId")]
        [Authorize(Roles = "Member, Trainer")]
        public async Task<IActionResult> GetWeeklyProgressesBySubsId(string subscriptionId)
        {
            GetWeeklyProgressesBySubsIdQueryRequest request = new(Guid.Parse(subscriptionId));
            var response = await _mediator.Send(request);
            return response.Success ? Ok(response) : BadRequest(response);
        }
    }
}
