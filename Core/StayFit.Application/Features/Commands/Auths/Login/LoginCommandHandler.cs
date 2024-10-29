using MediatR;
using StayFit.Application.DTOs;
using StayFit.Application.Repositories;

namespace StayFit.Application.Features.Commands.Auths.Login
{
    public class LoginCommandHandler : IRequestHandler<LoginCommandRequest, LoginCommandResponse>
    {
        private readonly IAuthRepository _authRepository;

        public LoginCommandHandler(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }

        public async Task<LoginCommandResponse> Handle(LoginCommandRequest request, CancellationToken cancellationToken)
        {
            TokenDto response = await _authRepository.LoginAsync(request.LoginModel);
            return new()
            {
                TokenModel = response,
            };
        }
    }
}
