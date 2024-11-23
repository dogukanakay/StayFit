using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StayFit.Application.Features.Commands.WorkoutPlans.DeleteWorkoutPlan
{
    public class DeleteWorkoutPlanCommandRequest : IRequest<DeleteWorkoutPlanCommandResponse>
    {
        public int WorkoutPlanId { get; set; }
    }
}
