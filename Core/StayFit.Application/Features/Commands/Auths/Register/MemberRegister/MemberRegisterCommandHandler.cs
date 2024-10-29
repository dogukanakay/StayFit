using MediatR;
using StayFit.Application.Repositories;

namespace StayFit.Application.Features.Commands.Auths.Register.MemberRegister
{
    public class MemberRegisterCommandHandler : IRequestHandler<MemberRegisterCommandRequest, MemberRegisterCommandResponse>
    {
        private readonly IAuthRepository _authRepository;

        public MemberRegisterCommandHandler(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }

        public async Task<MemberRegisterCommandResponse> Handle(MemberRegisterCommandRequest request, CancellationToken cancellationToken)
        {
            string response = await _authRepository.MemberRegisterAsync(request.MemberRegisterDto);
            
            return new() { Message = response, Success = true };
        }
    }
}
