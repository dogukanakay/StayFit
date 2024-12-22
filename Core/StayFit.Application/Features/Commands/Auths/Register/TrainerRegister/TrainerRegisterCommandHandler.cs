using AutoMapper;
using MediatR;
using StayFit.Application.Abstracts.Security;
using StayFit.Application.Exceptions.Auths;
using StayFit.Application.Repositories;
using StayFit.Domain.Entities;
using StayFit.Domain.Enums;

namespace StayFit.Application.Features.Commands.Auths.Register.TrainerRegister
{
    public class TrainerRegisterCommandHandler : IRequestHandler<TrainerRegisterCommandRequest, TrainerRegisterCommandResponse>
    {
        private readonly IAuthRepository _authRepository;
        private readonly IHashingHelper _hashingHelper;
        private readonly IMapper _mapper;

        public TrainerRegisterCommandHandler(IAuthRepository authRepository, IHashingHelper hashingHelper, IMapper mapper)
        {
            _authRepository = authRepository;
            _hashingHelper = hashingHelper;
            _mapper = mapper;
        }

        public async Task<TrainerRegisterCommandResponse> Handle(TrainerRegisterCommandRequest request, CancellationToken cancellationToken)
        {

            if (await _authRepository.CheckIfEmailAlreadyExist(request.TrainerRegisterDto.Email))
                throw new EmailAlreadyExistException();
            if (await _authRepository.CheckIfPhoneAlreadyExist(request.TrainerRegisterDto.Phone))
                throw new PhoneAlreadyExistException();

            byte[] passwordHash, passwordSalt;
            _hashingHelper.CreatePasswordHash(request.TrainerRegisterDto.Password, out passwordHash, out passwordSalt);
            User user = _mapper.Map<User>(request.TrainerRegisterDto);
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            user.Status = UserStatus.Active;
            user.IsEmailConfirmed = true;
            user.UserRole = UserRole.Trainer;

            

            Trainer trainer = new()
            {
                User = user,
                Bio = request.TrainerRegisterDto.Bio,
                CreatedDate = user.CreatedDate,
                MonthlyRate = request.TrainerRegisterDto.MonthlyRate,
                Rate = 3,
                YearsOfExperience = request.TrainerRegisterDto.YearsOfExperience,
                Specializations = request.TrainerRegisterDto.Specializations,
            };

            int response = await _authRepository.TrainerRegisterAsync(trainer);

            return response > 0 ? new("Kayıt başarılı.", true) { } : new("Kayıt başarısız.", false);

        }
    }

}
