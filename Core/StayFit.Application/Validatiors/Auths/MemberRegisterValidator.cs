using FluentValidation;
using StayFit.Application.Constants.Messages;
using StayFit.Application.DTOs;
using StayFit.Application.DTOs.Abstracts;
using StayFit.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StayFit.Application.Validatiors.Auths
{
    public class MemberRegisterValidator : AbstractValidator<MemberRegisterDto>
    {
        public MemberRegisterValidator()
        {
            RuleFor(r => r.Password)
                .NotEmpty().WithMessage(Messages.PasswordCannotBeEmpty)
                .MinimumLength(8).WithMessage(Messages.PasswordMinLength)
                .MaximumLength(36).WithMessage(Messages.PasswordMaxLength)
                .Matches(@"[A-Z]").WithMessage(Messages.PasswordMustContainUppercase)
                .Matches(@"[a-z]").WithMessage(Messages.PasswordMustContainLowercase)
                .Matches(@"[0-9]").WithMessage(Messages.PasswordMustContainDigit)
                .Must(password => !password.Contains(" ")).WithMessage(Messages.PasswordCannotContainSpaces);

            RuleFor(r => r.Email)
                .NotEmpty().WithMessage(Messages.EmailCannotBeEmpty)
                .EmailAddress().WithMessage(Messages.InvalidEmailFormat)
                .Matches(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$")
                .WithMessage(Messages.EmailFormatNotValid);

            RuleFor(r => r.Phone)
                .NotEmpty().WithMessage(Messages.PhoneCannotBeEmpty)
                .Matches(@"^\+?[1-9][0-9]{7,14}$").WithMessage(Messages.InvalidPhoneNumber)
                .MaximumLength(15).WithMessage(Messages.PhoneMaxLengthExceeded);

            RuleFor(r => r.FirstName)
                .NotEmpty().WithMessage(Messages.FirstNameCannotBeEmpty)
                .MaximumLength(50).WithMessage(Messages.FirstNameMaxLengthExceeded);

            RuleFor(r => r.LastName)
                .NotEmpty().WithMessage(Messages.LastNameCannotBeEmpty)
                .MaximumLength(50).WithMessage(Messages.LastNameMaxLengthExceeded);

            RuleFor(r => r.Weight)
                .GreaterThan(0).WithMessage(Messages.WeightCannotBeEmptyOrZero)
                .NotEmpty().WithMessage(Messages.WeightCannotBeEmptyOrZero);
                

            RuleFor(r => r.Height)
                .GreaterThan(0).WithMessage(Messages.WeightCannotBeEmptyOrZero)
                .NotEmpty().WithMessage(Messages.HeightCannotBeEmptyOrZero);



        }


    }
}
