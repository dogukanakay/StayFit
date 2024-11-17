using StayFit.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StayFit.Application.Abstracts.Services
{
    public interface IAuthService
    {
        Task<int> MemberRegisterAsync(Member member);
    }
}
