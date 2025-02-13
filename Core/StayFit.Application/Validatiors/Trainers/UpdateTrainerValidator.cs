using FluentValidation;
using StayFit.Application.Constants.Messages;
using StayFit.Application.DTOs.Trainers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StayFit.Application.Validatiors.Trainers
{
    public class UpdateTrainerValidator : AbstractValidator<UpdateTrainerDto>
    {
        public UpdateTrainerValidator()
        {
            RuleFor(r => r.FirstName)
             .NotEmpty().WithMessage(Messages.FirstNameCannotBeEmpty)
             .MaximumLength(50).WithMessage(Messages.FirstNameMaxLengthExceeded);

            RuleFor(r => r.LastName)
                .NotEmpty().WithMessage(Messages.LastNameCannotBeEmpty)
                .MaximumLength(50).WithMessage(Messages.LastNameMaxLengthExceeded);

            RuleFor(r => r.Bio)
                .NotEmpty().WithMessage(Messages.BioCannotBeEmpty)
                .MinimumLength(30).WithMessage(Messages.BioMinLength)
                .MaximumLength(200).WithMessage(Messages.BioMaxLength);

            RuleFor(r => r.YearsOfExperience)
                .GreaterThanOrEqualTo(0).WithMessage(Messages.CannotBeNegative);
            
            RuleFor(r => r.MonthlyRate)
                .GreaterThanOrEqualTo(0).WithMessage(Messages.CannotBeNegative);
        }
    }
}
