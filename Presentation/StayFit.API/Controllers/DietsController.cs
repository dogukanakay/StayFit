using MediatR;
using Microsoft.AspNetCore.Mvc;
using StayFit.Application.DTOs.Diets;
using StayFit.Application.Features.Commands.Diets.CreateDiet;
using StayFit.Application.Features.Commands.Diets.DeleteDiet;
using StayFit.Application.Features.Commands.Diets.UpdateDietByAI;
using StayFit.Application.Features.Queries.Diets.GetDietsByDietDayId;

namespace StayFit.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DietsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DietsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> CreateDietList(List<CreateDietDto> createDietDtos)
        {
            var request = new CreateDietCommandRequest(createDietDtos);
            var response = await _mediator.Send(request);

            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetDietSByDietDayId(int dietDayId)
        {
            var request = new GetDietsByDietDayIdQueryRequest(dietDayId);
            var response = await _mediator.Send(request);

            return response.Success ? Ok(response) : NotFound(response);
        }

        [HttpDelete("[action]")]
        public async Task<IActionResult> DeleteDiet(int dietId)
        {
            var request = new DeleteDietCommandRequest(dietId);
            var response = await _mediator.Send(request);

            return response.Success ? Ok(response) : BadRequest(response);

        }

        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateDietByAI(int dietId)
        {
            var request = new UpdateDietByAICommandRequest(dietId);
            var response = await _mediator.Send(request);
            return response.Success ? Ok(response) : NotFound(response);
        }
    }
}
