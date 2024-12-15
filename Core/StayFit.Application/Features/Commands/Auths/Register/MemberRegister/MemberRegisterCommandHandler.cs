using AutoMapper;
using MediatR;
using StayFit.Application.Abstracts.Security;
using StayFit.Application.Exceptions.Auths;
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

        public MemberRegisterCommandHandler(IAuthRepository authRepository, IHashingHelper hashingHelper, IMapper mapper)
        {
            _authRepository = authRepository;
            _hashingHelper = hashingHelper;
            _mapper = mapper;
        }

        public async Task<MemberRegisterCommandResponse> Handle(MemberRegisterCommandRequest request, CancellationToken cancellationToken)
        {
            if (await _authRepository.CheckIfEmailAlreadyExist(request.MemberRegisterDto.Email))
                throw new EmailAlreadyExistException();
            if (await _authRepository.CheckIfPhoneAlreadyExist(request.MemberRegisterDto.Phone))
                throw new PhoneAlreadyExistException();

            byte[] passwordHash, passwordSalt;
            _hashingHelper.CreatePasswordHash(request.MemberRegisterDto.Password, out passwordHash, out passwordSalt);

            User user = _mapper.Map<User>(request.MemberRegisterDto);
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            user.Status = UserStatus.Active;
            user.IsEmailConfirmed = true;
            user.UserRole = UserRole.Member;

            Member member = new()
            {
                CreatedDate = user.CreatedDate,
                Id = user.Id,
                Height = request.MemberRegisterDto.Height,
                Weight = request.MemberRegisterDto.Weight,
                User = user
            };

            int response = await _authRepository.MemberRegisterAsync(member);

            
            
            return response>0 ? new("Kayıt başarılı.",true) { } : new("Kayıt başarısız.", false);
        }
    }
}
