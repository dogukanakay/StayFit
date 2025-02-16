using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StayFit.Application.Features.Commands.DietDays.DeleteDietDay
{
    public class DeleteDietDayCommandRequest : IRequest<DeleteDietDayCommandResponse>
    {
        public int DietDayId { get;}
        public Guid TrainerId { get; }

        public DeleteDietDayCommandRequest(int dietDayId, Guid trainerId)
        {
            DietDayId = dietDayId;
            TrainerId = trainerId;
        }
    }
}
