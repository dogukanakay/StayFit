using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StayFit.Application.Features.Commands.WorkoutDays.UpdateWorkoutDayCompleted
{
    public class UpdateWorkoutDayCompletedCommandRequest : IRequest<UpdateWorkoutDayCompletedCommandResponse>
    {
        public Guid MemberId { get; }
        public int WorkoutDayId { get;}

        public UpdateWorkoutDayCompletedCommandRequest(Guid memberId, int workoutDayId)
        {
            MemberId = memberId;
            WorkoutDayId = workoutDayId;
        }
    }
}
