using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StayFit.Application.Features.Queries.Members.GetMemberProfile;
using StayFit.Application.Features.Queries.Trainers.GetTrainerProfile;
using System.Security.Claims;

namespace StayFit.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembersController : ControllerBase
    {

        private readonly IMediator _mediator;

        public MembersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetMemberProfile")]
        public async Task<IActionResult> GetMyProfile()
        {
            string? userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            GetMemberProfileQueryRequest request = new() { MemberId = Guid.Parse(userId) };
            GetMemberProfileQueryResponse response = await _mediator.Send(request);

            return Ok(response.MemberResponseDto);
        }
    }
}
