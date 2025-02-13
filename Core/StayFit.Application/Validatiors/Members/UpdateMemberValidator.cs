using FluentValidation;
using StayFit.Application.Constants.Messages;
using StayFit.Application.DTOs.Members;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StayFit.Application.Validatiors.Members
{
    public class UpdateMemberValidator : AbstractValidator<UpdateMemberDto>
    {
        public UpdateMemberValidator()
        {
            RuleFor(r => r.FirstName)
               .NotEmpty().WithMessage(Messages.FirstNameCannotBeEmpty)
               .MaximumLength(50).WithMessage(Messages.FirstNameMaxLengthExceeded);

            RuleFor(r => r.LastName)
                .NotEmpty().WithMessage(Messages.LastNameCannotBeEmpty)
                .MaximumLength(50).WithMessage(Messages.LastNameMaxLengthExceeded);

            RuleFor(r => r.Weight)
                .NotEmpty().WithMessage(Messages.WeightCannotBeEmptyOrZero);

            RuleFor(r => r.Height)
                .NotEmpty().WithMessage(Messages.HeightCannotBeEmptyOrZero);
        }
    }
}
