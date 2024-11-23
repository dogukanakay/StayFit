using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StayFit.Application.Features.Commands.WorkoutDays.DeleteWorkoutDay
{
    public class DeleteWorkoutDayCommandRequest : IRequest<DeleteWorkoutDayCommandResponse>
    {
        public int WorkoutDayId { get; set; }
    }
}
