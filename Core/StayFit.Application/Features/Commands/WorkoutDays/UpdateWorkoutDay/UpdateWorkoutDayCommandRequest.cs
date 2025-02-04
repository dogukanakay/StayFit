using MediatR;
using StayFit.Application.DTOs.WorkoutDays;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StayFit.Application.Features.Commands.WorkoutDays.UpdateWorkoutDay
{
    public class UpdateWorkoutDayCommandRequest : IRequest<UpdateWorkoutDayCommandResponse>
    {
        public UpdateWorkoutDayDto UpdateWorkoutDayDto { get; }

        public UpdateWorkoutDayCommandRequest(UpdateWorkoutDayDto updateWorkoutDayDto)
        {
            UpdateWorkoutDayDto = updateWorkoutDayDto;
        }
    }
}
