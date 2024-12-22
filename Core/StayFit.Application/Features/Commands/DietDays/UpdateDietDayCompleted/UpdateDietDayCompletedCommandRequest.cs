using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StayFit.Application.Features.Commands.DietDays.UpdateDietDayCompleted
{
    public class UpdateDietDayCompletedCommandRequest : IRequest<UpdateDietDayCompletedCommandResponse>
    {
        public Guid MemberId { get;}
        public int DietDayId { get; }

        public UpdateDietDayCompletedCommandRequest(Guid memberId, int dietDayId)
        {
            MemberId = memberId;
            DietDayId = dietDayId;
        }
    }
}
