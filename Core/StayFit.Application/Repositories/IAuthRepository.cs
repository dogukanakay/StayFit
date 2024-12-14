using StayFit.Application.DTOs;
using StayFit.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StayFit.Application.Repositories
{
    public interface IAuthRepository
    {
        Task<int> TrainerRegisterAsync(Trainer trainer);
        Task<int> MemberRegisterAsync(Member member);
        Task<User> GetUserByEmail(string email);

        Task<bool> CheckIfEmailAlreadyExist(string email);
        Task<bool> CheckIfPhoneAlreadyExist(string phone);
    }
}
