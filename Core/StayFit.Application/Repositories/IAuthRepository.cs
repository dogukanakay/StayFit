using StayFit.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StayFit.Application.Repositories
{
    public interface IAuthRepository
    {
        Task<string> TrainerRegisterAsync(TrainerRegisterDto trainerRegisterDto);
        Task<string> MemberRegisterAsync(MemberRegisterDto memberRegisterDto);
        Task<TokenDto> LoginAsync(LoginDto loginDto);

        Task<bool> CheckIfEmailAlreadyExist(string email);
        Task<bool> CheckIfPhoneAlreadyExist(string phone);
    }
}
