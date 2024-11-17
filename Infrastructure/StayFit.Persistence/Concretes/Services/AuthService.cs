using AutoMapper;
using StayFit.Application.Abstracts.Security;
using StayFit.Application.Abstracts.Services;
using StayFit.Application.Repositories;
using StayFit.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StayFit.Persistence.Concretes.Services
{
    public class AuthService : IAuthService
    {

        private readonly IAuthRepository _authRepository;
        private readonly IHashingHelper _hashingHelper;

        public AuthService(IAuthRepository authRepository, IHashingHelper hashingHelper)
        {
            _authRepository = authRepository;
            _hashingHelper = hashingHelper;
        }
        public Task<int> MemberRegisterAsync(Member member)
        {
            throw new NotImplementedException();
        }
    }
}
