using MediatR;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using StayFit.Application.DTOs;
using StayFit.Application.Features.Commands.Auths.Login.MemberLogin;
using StayFit.Application.Features.Commands.Auths.Login.TrainerLogin;
using StayFit.Application.Features.Commands.Auths.Register.MemberRegister;
using StayFit.Application.Features.Commands.Auths.Register.TrainerRegister;

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
            var result = await _mediator.Send(request);
            return Ok(result);
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


    }
}
