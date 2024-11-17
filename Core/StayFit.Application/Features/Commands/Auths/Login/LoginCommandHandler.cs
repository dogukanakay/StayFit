using MediatR;
using StayFit.Application.Abstracts.Security;
using StayFit.Application.DTOs;
using StayFit.Application.Exceptions;
using StayFit.Application.Repositories;
using StayFit.Domain.Entities;

namespace StayFit.Application.Features.Commands.Auths.Login
{
    public class LoginCommandHandler : IRequestHandler<LoginCommandRequest, LoginCommandResponse>
    {
        private readonly IAuthRepository _authRepository;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IHashingHelper _hashingHelper;

        public LoginCommandHandler(IAuthRepository authRepository, IJwtTokenGenerator jwtTokenGenerator, IHashingHelper hashingHelper)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _hashingHelper = hashingHelper;
            _authRepository = authRepository;
        }



        public async Task<LoginCommandResponse> Handle(LoginCommandRequest request, CancellationToken cancellationToken)
        {
            User user = await _authRepository.GetUserByEmail(request.LoginModel.Email);
            if (user == null)
                throw new UserNotFoundException();
            if (_hashingHelper.VerifyPasswordHash(request.LoginModel.Password, user.PasswordHash, user.PasswordSalt))
            {

                TokenDto response = new()
                {
                    Message = "Giriş Başarılı",
                    Success = true,
                    Token = await _jwtTokenGenerator.GenerateToken(user)
                };
                return new()
                {
                    TokenModel = response,
                };
            }
            throw new UserNotFoundException("Hatalı şifre veya kullanıcı adı.");

        }
    }
}
