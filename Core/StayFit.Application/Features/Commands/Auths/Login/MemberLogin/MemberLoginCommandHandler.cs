using MediatR;
using StayFit.Application.Abstracts.Security;
using StayFit.Application.DTOs;
using StayFit.Application.Exceptions;
using StayFit.Application.Repositories;
using StayFit.Domain.Entities;
using StayFit.Domain.Enums;

namespace StayFit.Application.Features.Commands.Auths.Login.MemberLogin
{
    public class MemberLoginCommandHandler : IRequestHandler<MemberLoginCommandRequest, MemberLoginCommandResponse>
    {
        private readonly IAuthRepository _authRepository;
        private readonly IHashingHelper _hashingHelper;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;

        public MemberLoginCommandHandler(IAuthRepository authRepository, IHashingHelper hashingHelper, IJwtTokenGenerator jwtTokenGenerator)
        {
            _authRepository = authRepository;
            _hashingHelper = hashingHelper;
            _jwtTokenGenerator = jwtTokenGenerator;
        }

        public async Task<MemberLoginCommandResponse> Handle(MemberLoginCommandRequest request, CancellationToken cancellationToken)
        {
            User user = await _authRepository.GetUserByEmail(request.LoginDto.Email);
            if (user == null)
                throw new UserNotFoundException();
            if (user.UserRole != UserRole.Member)
                throw new UserNotFoundException("Bu kayıtlara ait bir üye bulunmamaktadır.");
            if (_hashingHelper.VerifyPasswordHash(request.LoginDto.Password, user.PasswordHash, user.PasswordSalt))
            {
                return new("Giriş başarılı", true, await _jwtTokenGenerator.GenerateToken(user));

            }
            throw new UserNotFoundException("Hatalı şifre veya kullanıcı adı.");
        }
    }
}
