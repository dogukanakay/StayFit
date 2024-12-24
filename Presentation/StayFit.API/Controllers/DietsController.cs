using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using StayFit.Application.DTOs.Diets;
using StayFit.Application.Features.Commands.Diets.CreateDiet;
using StayFit.Application.Features.Commands.Diets.DeleteDiet;
using StayFit.Application.Features.Commands.Diets.UpdateDietByAI;
using StayFit.Application.Features.Queries.Diets.GetDietsByDietDayId;
using StayFit.Application.Features.Queries.Diets.GetTodaysDietsByMemberId;
using System.Security.Claims;

namespace StayFit.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DietsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IConfiguration _configuration;

        public DietsController(IMediator mediator, IConfiguration configuration)
        {
            _mediator = mediator;
            _configuration = configuration;
        }

        [HttpPost("[action]")]
        [Authorize(Roles = "Trainer")]
        public async Task<IActionResult> CreateDietList(List<CreateDietDto> createDietDtos)
        {
            var request = new CreateDietCommandRequest(createDietDtos);
            var response = await _mediator.Send(request);

            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpGet("[action]")]
        [Authorize(Roles = "Trainer, Member")]
        public async Task<IActionResult> GetDietSByDietDayId(int dietDayId)
        {

            var request = new GetDietsByDietDayIdQueryRequest(dietDayId);
            var response = await _mediator.Send(request);

            return response.Success ? Ok(response) : NotFound(response);
        }

        [HttpDelete("[action]")]
        [Authorize(Roles = "Trainer")]
        public async Task<IActionResult> DeleteDiet(int dietId)
        {
            var request = new DeleteDietCommandRequest(dietId);
            var response = await _mediator.Send(request);

            return response.Success ? Ok(response) : BadRequest(response);

        }

        [HttpPut("[action]")]
        [Authorize(Roles = "Trainer, Member")]
        public async Task<IActionResult> UpdateDietByAI(int dietId)
        {
            string prompt = _configuration["Prompts:GetNewDiet"];
            var request = new UpdateDietByAICommandRequest(dietId, prompt);
            var response = await _mediator.Send(request);
            return response.Success ? Ok(response) : NotFound(response);
        }

        [HttpGet("[action]")]
        [Authorize(Roles = "Member")]
        public async Task<IActionResult> GetTodaysDiets()
        {
            string? memberId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var request = new GetTodaysDietsByMemberIdQueryRequest(Guid.Parse(memberId));
            var response = await _mediator.Send(request);

            return response.Success ? Ok(response) : NotFound(response);


        }
    }
}
