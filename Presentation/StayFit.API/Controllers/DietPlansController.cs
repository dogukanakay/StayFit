using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StayFit.Application.DTOs.DietPlans;
using StayFit.Application.Features.Commands.DietPlans.CreateDietPlan;
using StayFit.Application.Features.Queries.DietPlans.GetDietPlansByMemberId;
using StayFit.Application.Features.Queries.DietPlans.GetDietPlansBySubscriptionId;
using System.Security.Claims;

namespace StayFit.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DietPlansController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DietPlansController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("CreateDietPlan")]
        public async Task<IActionResult> CreateDietPlan(CreateDietPlanDto createDietPlanDto)
        {
            CreateDietPlanCommandRequest request = new() { CreateDietPlanDto = createDietPlanDto };
            CreateDietPlanCommandResponse response = await _mediator.Send(request);

            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetDietPlansBySubscriptionId(string subscriptionId)
        {
            if (!Guid.TryParse(subscriptionId, out var subscriptionIdGuid))
                return BadRequest("Hatalı subscription id.");

            var request = new GetDietPlansBySubscriptionIdQueryRequest(subscriptionIdGuid);
            var response = await _mediator.Send(request);

            return response.Success ? Ok(response) : NotFound(response);
        }

        [HttpGet("[action]")]
        [Authorize(Roles ="Member")]
        public async Task<IActionResult> GetDietPlansByMemberId()
        {
            var memberId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (!Guid.TryParse(memberId, out var memberIdIdGuid))
                return BadRequest("Hatalı Kullanıcı id.");

            var request = new GetDietPlansByMemberIdQueryRequest(memberIdIdGuid);
            var response = await _mediator.Send(request);

            return response.Success ? Ok(response) : NotFound(response);
        }
    }
}
