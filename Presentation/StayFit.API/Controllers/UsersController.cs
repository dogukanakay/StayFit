using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StayFit.Application.Features.Commands.Users.UpdateUserPhoto;
using System.Security.Claims;

namespace StayFit.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IConfiguration _configuration;

        public UsersController(IMediator mediator, IConfiguration configuration)
        {
            _mediator = mediator;
            _configuration = configuration;
        }

        [HttpPut("UpdateProfilePhoto")]

        public async Task<IActionResult> UpdateProfilePhoto()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            string baseStorageUrl = _configuration["BaseStorageUrl"];
            var request = new UpdateUserPhotoCommandRequest(Request.Form.Files, Guid.Parse(userId), baseStorageUrl);
            var response = await _mediator.Send(request);

            return response.Success ? Ok(response) : BadRequest(response);
        }
    }
}
