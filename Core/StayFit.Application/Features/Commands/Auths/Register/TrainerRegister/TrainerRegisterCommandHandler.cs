using AutoMapper;
using MediatR;
using StayFit.Application.Abstracts.Security;
using StayFit.Application.Constants.Messages;
using StayFit.Application.DTOs;
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

        public TrainerRegisterCommandHandler(
            IAuthRepository authRepository,
            IHashingHelper hashingHelper,
            IMapper mapper)
        {
            _authRepository = authRepository;
            _hashingHelper = hashingHelper;
            _mapper = mapper;
        }

        public async Task<TrainerRegisterCommandResponse> Handle(TrainerRegisterCommandRequest request, CancellationToken cancellationToken)
        {
            if (await _authRepository.CheckIfEmailAlreadyExist(request.TrainerRegisterDto.Email))
                return new(Messages.EmailAlreadyExists, false);
            if (await _authRepository.CheckIfPhoneAlreadyExist(request.TrainerRegisterDto.Phone))
                return new(Messages.PhoneAlreadyExists, false);

            var user = CreateUser(request.TrainerRegisterDto);
            var trainer = CreateTrainer(user, request.TrainerRegisterDto);

            int response = await _authRepository.TrainerRegisterAsync(trainer);

            return response > 0
                ? new(Messages.RegistrationSuccessful, true)
                : new(Messages.RegistrationFailed, false);
        }

        private User CreateUser(TrainerRegisterDto dto)
        {
            _hashingHelper.CreatePasswordHash(dto.Password, out var passwordHash, out var passwordSalt);

            var user = _mapper.Map<User>(dto);
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            user.Status = UserStatus.Active;
            user.IsEmailConfirmed = true;
            user.UserRole = UserRole.Trainer;

            return user;
        }

        private Trainer CreateTrainer(User user, TrainerRegisterDto dto)
        {
            return new Trainer
            {
                User = user,
                Bio = dto.Bio,
                CreatedDate = user.CreatedDate,
                MonthlyRate = dto.MonthlyRate,
                Rate = 3,
                YearsOfExperience = dto.YearsOfExperience,
                Specializations = dto.Specializations
            };
        }
    }
}