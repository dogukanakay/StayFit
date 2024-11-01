using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StayFit.Application.DTOs.Members;
using StayFit.Application.Features.Commands.Members.UpdateMember;
using StayFit.Application.Features.Queries.Members.GetAllMembers;
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

        [HttpGet("GetAllMembersIncludeUser")]
        public async Task<IActionResult> GetAllMembersIncludeUser()
        {
            GetAllMembersQueryRequest request = new();
            GetAllMembersQueryResult response = await _mediator.Send(request);
            return Ok(response.MemberResponseDtos);
        }

        [HttpPut("UpdateMemberProfile")]
        public async Task<IActionResult> UpdateMemberProfile(UpdateMemberDto updateMemberDto)
        {
            UpdateMemberCommandRequest request = new() { UpdateMemberDto = updateMemberDto };
            UpdateMemberCommandResponse response = await _mediator.Send(request);
            if (response.Success)
                return Ok(response);

            return BadRequest(response);


        }
    }
}
