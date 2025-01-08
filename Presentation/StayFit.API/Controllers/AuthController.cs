using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using StayFit.Application.DTOs;
using StayFit.Application.DTOs.Auths;
using StayFit.Application.Features.Commands.Auths.Login.MemberLogin;
using StayFit.Application.Features.Commands.Auths.Login.TrainerLogin;
using StayFit.Application.Features.Commands.Auths.Password;
using StayFit.Application.Features.Commands.Auths.Register.MemberRegister;
using StayFit.Application.Features.Commands.Auths.Register.TrainerRegister;
using System.Security.Claims;

namespace StayFit.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {

            _mediator = mediator;
        }

        [HttpPost("MemberRegister")]
        public async Task<IActionResult> MemberRegisterAsync(MemberRegisterDto memberRegisterDto)
        {
            MemberRegisterCommandRequest request = new() { MemberRegisterDto = memberRegisterDto };
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpPost("TrainerRegister")]
        public async Task<IActionResult> TrainerRegisterAsync(TrainerRegisterDto trainerRegisterDto)
        {
            TrainerRegisterCommandRequest request = new() { TrainerRegisterDto = trainerRegisterDto };
            var response = await _mediator.Send(request);
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpPost("MemberLogin")]
        public async Task<IActionResult> MemberLoginAsync(LoginDto loginModel)
        {
            var request = new MemberLoginCommandRequest(loginModel);
            var response = await _mediator.Send(request);
            if (response.Success)
                Log.Information($"{loginModel.Email} kullanıcı giriş yaptı.");
            return Ok(response);
        }


        [HttpPost("TrainerLogin")]
        public async Task<IActionResult> TrainerLoginAsync(LoginDto loginModel)
        {
            var request = new TrainerLoginCommandRequest(loginModel);
            var response = await _mediator.Send(request);
            if (response.Success)
                Log.Information($"{loginModel.Email} kullanıcı giriş yaptı.");
            return Ok(response);
        }

        [HttpPut("UpdatePassword")]
        [Authorize(Roles ="Member, Trainer")]
        public async Task<IActionResult> UpdatePassword(UpdatePasswordDto updatePasswordDto)
        {
            string? userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var request = new UpdatePasswordCommandRequest(updatePasswordDto, Guid.Parse(userId));
            var response = await _mediator.Send(request);

            return response.Success ? Ok(response) : BadRequest(response);
        }


    }
}
