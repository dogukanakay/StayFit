﻿using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StayFit.Application.DTOs.WeeklyProgresses;
using StayFit.Application.Features.Commands.WeeklyProgresses.CreateWeeklyProgress;
using StayFit.Application.Features.Commands.WeeklyProgresses.CreateWeeklyProgressByAI;
using StayFit.Application.Features.Queries.WeeklyProgresses.GetWeeklyProgressesBySubsId;

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

        [HttpPost("CreateWeeklyProgress")]
        public async Task<IActionResult> CreateWeeklyProgress([FromForm] CreateWeeklyProgressDto createWeeklyProgressDto, [FromForm] IFormFileCollection files)
        {
            if (!Request.HasFormContentType)
            {
                return BadRequest("Content-Type must be multipart/form-data.");
            }

            var request = new CreateWeeklyProgressCommandRequest
            {
                Images = files,
                CreateWeeklyProgressDto = createWeeklyProgressDto,
                BaseStorageUrl = _configuration["BaseStorageUrl"]
            };

            CreateWeeklyProgressCommandResponse response = await _mediator.Send(request);

            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpPost("CreateWeeklyProgressByAI")]
        public async Task<IActionResult> CreateWeeklyProgressByAI([FromForm] CreateWeeklyProgressByAIDto createWeeklyProgressByAIDto, [FromForm] IFormFileCollection files)
        {
            var request = new CreateWeeklyProgressByAICommandRequest
            {
                Images = files,
                CreateWeeklyProgressByAIDto = createWeeklyProgressByAIDto,
                BaseStorageUrl = _configuration["BaseStorageUrl"]
            };

            CreateWeeklyProgressByAICommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("GetWeeklyProgressesBySubsId")]
        public async Task<IActionResult> GetWeeklyProgressesBySubsId(string SubscriptionId)
        {
            GetWeeklyProgressesBySubsIdQueryRequest request = new() { SubscriptionId = Guid.Parse(SubscriptionId) };
            GetWeeklyProgressesBySubsIdQueryResponse response = await _mediator.Send(request);
            return response.Success ? Ok(response) : BadRequest(response);
        }
    }
}
