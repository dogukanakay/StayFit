using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StayFit.Application.Features.Commands.DietDays.ResetCompletedDietDays
{
    public class ResetCompletedDietDaysCommandRequest : IRequest<ResetCompletedDietDaysCommandResponse>
    {
    }
}
