using MediatR;
using Microsoft.AspNetCore.Mvc;
using StayFit.Application.DTOs;
using StayFit.Application.Features.Commands.Auths.Login;
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
            TrainerRegisterCommandRequest request = new() { TrainerRegisterDto = trainerRegisterDto};
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> LoginAsync(LoginDto loginModel)
        {
            LoginCommandRequest loginCommandRequest = new()
            {
                LoginModel = loginModel
            };
            LoginCommandResponse response = await _mediator.Send(loginCommandRequest);
            return Ok(response.TokenModel);
        }


    }
}
