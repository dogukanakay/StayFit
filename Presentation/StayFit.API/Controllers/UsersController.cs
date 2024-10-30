using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StayFit.Application.Features.Queries.Members.GetMemberProfile;
using StayFit.Application.Features.Queries.Trainers.GetTrainerProfile;
using StayFit.Domain.Enums;
using System.Security.Claims;

namespace StayFit.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        //It is not okay for single responsibility
        //[HttpGet("GetMyProfile")]
        //public async Task<IActionResult> GetMyProfile()
        //{
        //    string? userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        //    var role = User.FindFirst(ClaimTypes.Role)?.Value;
        //    if(role == UserRole.Trainer.ToString())
        //    {
        //        GetTrainerProfileQueryRequest request = new() { TrainerId = Guid.Parse(userId) };
        //        GetTrainerProfileQueryResponse response = await _mediator.Send(request);
        //        return Ok(response.TrainerResponseDto);
        //    }
        //    else
        //    {
        //        GetMemberProfileQueryRequest request = new() { MemberId = Guid.Parse(userId) };
        //        GetMemberProfileQueryResponse response = await _mediator.Send(request);
        //        return Ok(response.MemberResponseDto);
        //    }
            
        //}
    }
}
