using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StayFit.Application.DTOs.DietDays;
using StayFit.Application.Features.Commands.DietDays.CreateDietDay;
using StayFit.Application.Features.Commands.DietDays.DeleteDietDay;
using StayFit.Application.Features.Commands.DietDays.UpdateDietDayCompleted;
using StayFit.Application.Features.Queries.DietDays.GetDietDaysByDietPlanId;
using StayFit.Domain.Entities;
using System.Security.Claims;

namespace StayFit.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DietDaysController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DietDaysController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("[action]")]
        [Authorize(Roles = "Trainer")]
        public async Task<IActionResult> CreateDietDay(CreateDietDayDto createDietDayDto)
        {
            Guid trainerId = Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            var request = new CreateDietDayCommandRequest(createDietDayDto, trainerId);
            var response = await _mediator.Send(request);

            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpDelete("[action]")]
        [Authorize(Roles = "Trainer")]
        public async Task<IActionResult> DeleteDietDay(int dietDayId)
        {
            string trainerId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var request = new DeleteDietDayCommandRequest(dietDayId, Guid.Parse(trainerId));
            var response = await _mediator.Send(request);

            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpGet("[action]")]
        [Authorize(Roles = "Trainer, Member")]
        public async Task<IActionResult> GetDietDaysByDietPlanId(int dietPlanId)
        {
            string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var request = new GetDietDaysByDietPlanIdQueryRequest(dietPlanId, Guid.Parse(userId));
            var response = await _mediator.Send(request);

            return response.Success ? Ok(response) : BadRequest(response);

        }

        [HttpPut("[action]")]
        [Authorize(Roles = "Member")]
        public async Task<IActionResult> DietDayCompleted(int dietDayId)
        {
            string memberId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            var request = new UpdateDietDayCompletedCommandRequest(Guid.Parse(memberId), dietDayId);
            var response = await _mediator.Send(request);

            return response.Success ? Ok(response) : BadRequest(response);
        }


    }
}
