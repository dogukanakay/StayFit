using FluentValidation;
using StayFit.Application.Constants.Messages;
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
            RuleFor(up => up.NewPassword)
                .NotEmpty().WithMessage(Messages.PasswordCannotBeEmpty)
                .MinimumLength(8).WithMessage(Messages.PasswordMinLength)
                .MaximumLength(36).WithMessage(Messages.PasswordMaxLength)
                .Matches(@"[A-Z]").WithMessage(Messages.PasswordMustContainUppercase)
                .Matches(@"[a-z]").WithMessage(Messages.PasswordMustContainLowercase)
                .Matches(@"[0-9]").WithMessage(Messages.PasswordMustContainDigit)
                .Must(password => !password.Contains(" "))
                .WithMessage(Messages.PasswordCannotContainSpaces);

            RuleFor(up => up.CurrentPassword)
                .NotEmpty().WithMessage(Messages.CurrentPasswordCannotBeEmpty);

            RuleFor(up => up)
                .Must(up => !up.CurrentPassword.Equals(up.NewPassword))
                .WithMessage(Messages.NewPasswordCannotBeSameAsCurrent);
        }
    }
}
