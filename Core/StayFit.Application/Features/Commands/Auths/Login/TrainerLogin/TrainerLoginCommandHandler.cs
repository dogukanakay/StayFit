using MediatR;
using StayFit.Application.Abstracts.Security;
using StayFit.Application.Constants.Messages;
using StayFit.Application.Repositories;
using StayFit.Domain.Entities;
using StayFit.Domain.Enums;

namespace StayFit.Application.Features.Commands.Auths.Login.TrainerLogin
{
    public class TrainerLoginCommandHandler : IRequestHandler<TrainerLoginCommandRequest, TrainerLoginCommandResponse>
    {
        private readonly IAuthRepository _authRepository;
        private readonly IHashingHelper _hashingHelper;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;

        public TrainerLoginCommandHandler(IAuthRepository authRepository, IHashingHelper hashingHelper, IJwtTokenGenerator jwtTokenGenerator)
        {
            _authRepository = authRepository;
            _hashingHelper = hashingHelper;
            _jwtTokenGenerator = jwtTokenGenerator;
        }
        public async Task<TrainerLoginCommandResponse> Handle(TrainerLoginCommandRequest request, CancellationToken cancellationToken)
        {
            User user = await _authRepository.GetUserByEmail(request.LoginDto.Email);

            if (user == null || user.UserRole != UserRole.Trainer)
                return new(Messages.LoginFailed, false, null);


            if (_hashingHelper.VerifyPasswordHash(request.LoginDto.Password, user.PasswordHash, user.PasswordSalt))
                return new(Messages.LoginSuccessful, true, await _jwtTokenGenerator.GenerateToken(user));


            return new(Messages.LoginFailed, false, null);

        }
    }
}
