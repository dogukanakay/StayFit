using FluentValidation;
using StayFit.Application.DTOs.Auths;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StayFit.Application.Validatiors.Auths
{
    public class UpdatePasswordValidator : AbstractValidator<UpdatePasswordDto>
    {
        public UpdatePasswordValidator()
        {
            RuleFor(up=>up.NewPassword)
                .NotEmpty().WithMessage("Şifre boş bırakılamaz")
                .MinimumLength(8).WithMessage("Şifre en az 8 karakter olmalıdır.")
                .Matches(@"[A-Z]").WithMessage("Şifre en az bir büyük harf içermelidir.")
                .Matches(@"[a-z]").WithMessage("Şifre en az bir küçük harf içermelidir.")
                .Matches(@"[0-9]").WithMessage("Şifre en az bir rakam içermelidir.")
                .Must(password => !password.Contains(" ")).WithMessage("Şifre boşluk içeremez.");

            RuleFor(up => up.CurrentPassword)
                .NotEmpty().WithMessage("Güncel şifreniz boş bırakılamaz.");

            RuleFor(up => up)
                .Must(up => !up.CurrentPassword.Equals(up.NewPassword)).WithMessage("Güncel şifreniz ile yeni şifreniz aynı olamaz");
        }
    }
}
