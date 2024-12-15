using FluentValidation;
using StayFit.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StayFit.Application.Validatiors.Auths
{
    public class RegisterValidator : AbstractValidator<RegisterDto>
    {
        public RegisterValidator()
        {
            RuleFor(r => r.Password)
                .NotEmpty().WithMessage("Şifre boş bırakılamaz")
                .MinimumLength(8).WithMessage("Şifre en az 8 karakter olmalıdır.")
                .Matches(@"[A-Z]").WithMessage("Şifre en az bir büyük harf içermelidir.")
                .Matches(@"[a-z]").WithMessage("Şifre en az bir küçük harf içermelidir.")
                .Matches(@"[0-9]").WithMessage("Şifre en az bir rakam içermelidir.")
                .Must(password => !password.Contains(" ")).WithMessage("Şifre boşluk içeremez.");

            RuleFor(r => r.Email)
                .NotEmpty().WithMessage("E-posta adresi boş geçilemez.")
                .EmailAddress().WithMessage("Geçerli bir e-posta adresi giriniz.")
                .Matches(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$")
                .WithMessage("E-posta adresi uygun formatta değil.");

            RuleFor(r => r.Phone)
                .NotEmpty().WithMessage("Telefon numarası boş geçilemez.")
                .Matches(@"^\+?[1-9][0-9]{7,14}$")
                .WithMessage("Geçerli bir telefon numarası giriniz. (Örnek: +905555555555 veya 05555555555)")
                .MaximumLength(15).WithMessage("Telefon numarası 15 karakterden uzun olamaz.");


            RuleFor(r => r.FirstName)
                .NotEmpty().WithMessage("İsim boş geçilemez.")
                .MaximumLength(50).WithMessage("İsim 50 karakterden fazla olamaz.");

            RuleFor(r => r.LastName)
                .NotEmpty().WithMessage("İsim boş geçilemez.")
                .MaximumLength(50).WithMessage("İsim 50 karakterden fazla olamaz.");
        }
    }
}
