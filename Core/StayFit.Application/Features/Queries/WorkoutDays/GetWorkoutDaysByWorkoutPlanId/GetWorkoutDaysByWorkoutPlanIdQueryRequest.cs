using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StayFit.Application.Features.Queries.WorkoutDays.GetWorkoutDaysByWorkoutPlanId
{
    public class GetWorkoutDaysByWorkoutPlanIdQueryRequest : IRequest<GetWorkoutDaysByWorkoutPlanIdQueryResponse>
    {
        public int WorkoutPlanId { get; }

        public GetWorkoutDaysByWorkoutPlanIdQueryRequest(int workoutPlanId)
        {
            WorkoutPlanId = workoutPlanId;
        }
    }
}
