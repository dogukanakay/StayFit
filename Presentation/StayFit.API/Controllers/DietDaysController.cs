using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StayFit.Application.DTOs.DietDays;
using StayFit.Application.Features.Commands.DietDays.CreateDietDay;
using StayFit.Application.Features.Commands.DietDays.DeleteDietDay;
using StayFit.Application.Features.Queries.DietDays.GetDietDaysByDietPlanId;

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
        [Authorize(Roles ="Trainer")]
        public async Task<IActionResult> CreateDietDay(CreateDietDayDto createDietDayDto)
        {
            var request = new CreateDietDayCommandRequest(createDietDayDto);
            var response = await _mediator.Send(request);

            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpDelete("[action]")]
        [Authorize(Roles = "Trainer")]
        public async Task<IActionResult> DeleteDietDay(int dietDayId)
        {
            var request = new DeleteDietDayCommandRequest(dietDayId);
            var response = await _mediator.Send(request);

            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpGet("[action]")]
        [Authorize(Roles = "Trainer, Member")]
        public async Task<IActionResult> GetDietDaysByDietPlanId(int dietPlanId)
        {
            var request = new GetDietDaysByDietPlanIdQueryRequest(dietPlanId);
            var response = await _mediator.Send(request);

            return response.Success ? Ok(response) : BadRequest(response);


        }


    }
}
