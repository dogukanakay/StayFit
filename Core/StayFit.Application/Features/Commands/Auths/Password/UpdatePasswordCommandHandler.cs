﻿using MediatR;
using StayFit.Application.Abstracts.Security;
using StayFit.Application.Exceptions.Auths;
using StayFit.Application.Repositories;
using StayFit.Domain.Entities;

namespace StayFit.Application.Features.Commands.Auths.Password
{
    public class UpdatePasswordCommandHandler : IRequestHandler<UpdatePasswordCommandRequest, UpdatePasswordCommandResponse>
    {
        private readonly IAuthRepository _authRepository;
        private readonly IHashingHelper _hashingHelper;
        

        public UpdatePasswordCommandHandler(IAuthRepository authRepository, IHashingHelper hashingHelper)
        {
            _authRepository = authRepository;
            _hashingHelper = hashingHelper;
        }

        public async Task<UpdatePasswordCommandResponse> Handle(UpdatePasswordCommandRequest request, CancellationToken cancellationToken)
        {
            User user = await _authRepository.GetUserByIdAsync(request.UserId);

            if (user is null) throw new UserNotFoundException("Kullanıcı bulunamadı.");

            var verify = _hashingHelper.VerifyPasswordHash(request.UpdatePasswordDto.CurrentPassword, user.PasswordHash, user.PasswordSalt);

            if (!verify)
                return new(false, "Hatalı şifre.");
            byte[] newPasswordHash, newPasswordSalt;
            _hashingHelper.CreatePasswordHash(request.UpdatePasswordDto.NewPassword,out newPasswordHash, out newPasswordSalt);

            user.PasswordHash = newPasswordHash;
            user.PasswordSalt = newPasswordSalt;

            int result = await _authRepository.SaveChangesAsync();

            return result > 0 ? new(true, "Şifre başarıyla güncellendi.") : new(false, "Şifre güncellenemedi");

        }
    }
}