using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StayFit.Application.Features.Queries.FoodInformations.GetFoodInformationsByName;

namespace StayFit.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodInformationsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FoodInformationsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetFoodsByName(string foodName)
        {
            var request = new GetFoodInformationsByNameQueryRequest(foodName);
            var response =await _mediator.Send(request);

            return Ok(response.Foods);

        }
    }
}
