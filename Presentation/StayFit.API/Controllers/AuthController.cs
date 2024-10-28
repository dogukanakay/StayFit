using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StayFit.Application.Models;
using StayFit.Application.Repositories;

namespace StayFit.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _authRepository;

        public AuthController(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }

        [HttpPost("StudentRegister")]
        public async Task<IActionResult> StudentRegister(StudentRegisterModel studentRegisterModel)
        {
            var result = await _authRepository.StudentRegister(studentRegisterModel);
            return Ok(result);
        }

        [HttpPost("TrainerRegister")]
        public async Task<IActionResult> TrainerRegister(TrainerRegisterModel trainerRegisterModel)
        {
            var result = await _authRepository.TrainerRegister(trainerRegisterModel);
            return Ok(result);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            var result = await _authRepository.Login(loginModel);
            return Ok(result);
        }

        
    }
}
