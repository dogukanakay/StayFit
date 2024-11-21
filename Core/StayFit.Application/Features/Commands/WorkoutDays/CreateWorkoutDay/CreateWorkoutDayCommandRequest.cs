using MediatR;
using StayFit.Application.DTOs.WorkoutDays;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StayFit.Application.Features.Commands.WorkoutDays.CreateWorkoutDay
{
    public class CreateWorkoutDayCommandRequest : IRequest<CreateWorkoutDayCommandResponse>
    {
        public CreateWorkoutDayDto CreateWorkoutDayDto { get; set; }
    }
}
