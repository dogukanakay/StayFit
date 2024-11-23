using MediatR;
using StayFit.Application.DTOs.WorkoutPlans;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StayFit.Application.Features.Commands.WorkoutPlans.UpdateWorkoutPlan
{
    public class UpdateWorkoutPlanCommandRequest : IRequest<UpdateWorkoutPlanCommandResponse>  
    {
        public UpdateWorkoutPlanDto UpdateWorkoutPlanDto { get; set; }
    }
}
