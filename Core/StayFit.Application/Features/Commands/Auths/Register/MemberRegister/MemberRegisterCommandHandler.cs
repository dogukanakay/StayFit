using AutoMapper;
using MediatR;
using StayFit.Application.Abstracts.Security;
using StayFit.Application.Constants.Messages;
using StayFit.Application.DTOs;
using StayFit.Application.Repositories;
using StayFit.Domain.Entities;
using StayFit.Domain.Enums;

namespace StayFit.Application.Features.Commands.Auths.Register.MemberRegister
{
    public class MemberRegisterCommandHandler : IRequestHandler<MemberRegisterCommandRequest, MemberRegisterCommandResponse>
    {
        private readonly IAuthRepository _authRepository;
        private readonly IHashingHelper _hashingHelper;
        private readonly IMapper _mapper;

        public MemberRegisterCommandHandler(
            IAuthRepository authRepository,
            IHashingHelper hashingHelper,
            IMapper mapper)
        {
            _authRepository = authRepository;
            _hashingHelper = hashingHelper;
            _mapper = mapper;
        }

        public async Task<MemberRegisterCommandResponse> Handle(MemberRegisterCommandRequest request, CancellationToken cancellationToken)
        {
            if (await _authRepository.CheckIfEmailAlreadyExist(request.MemberRegisterDto.Email))
                return new(Messages.EmailAlreadyExists, false);
            if (await _authRepository.CheckIfPhoneAlreadyExist(request.MemberRegisterDto.Phone))
                return new(Messages.PhoneAlreadyExists, false);

            var user = CreateUser(request.MemberRegisterDto);
            var member = CreateMember(user, request.MemberRegisterDto);

            int response = await _authRepository.MemberRegisterAsync(member);

            return response > 0
                ? new(Messages.RegistrationSuccessful, true)
                : new(Messages.RegistrationFailed, false);
        }

        private User CreateUser(MemberRegisterDto dto)
        {
            _hashingHelper.CreatePasswordHash(dto.Password, out var passwordHash, out var passwordSalt);

            var user = _mapper.Map<User>(dto);
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            user.Status = UserStatus.Active;
            user.IsEmailConfirmed = true;
            user.UserRole = UserRole.Member;

            return user;
        }

        private Member CreateMember(User user, MemberRegisterDto dto)
        {
            return new Member
            {
                CreatedDate = user.CreatedDate,
                Height = dto.Height,
                Weight = dto.Weight,
                User = user
            };
        }
    }
}
