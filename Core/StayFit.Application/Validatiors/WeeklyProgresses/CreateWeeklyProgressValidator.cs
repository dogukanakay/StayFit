using FluentValidation;
using StayFit.Application.Constants.Messages;
using StayFit.Application.DTOs.WeeklyProgresses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StayFit.Application.Validatiors.WeeklyProgresses
{
    public class CreateWeeklyProgressValidator : AbstractValidator<CreateWeeklyProgressDto>
    {
        public CreateWeeklyProgressValidator()
        {
            RuleFor(wp => wp.WaistCircumference)
                .NotEmpty().WithMessage(Messages.WaistCircumferenceCannotBeEmpty);

            RuleFor(wp => wp.NeckCircumference)
                .NotEmpty().WithMessage(Messages.NeckCircumferenceCannotBeEmpty);

            RuleFor(wp => wp)
                .Must(wp => wp.WaistCircumference > wp.NeckCircumference)
                .WithMessage(Messages.WaistMustBeGreaterThanNeck);
        }
    }
}
