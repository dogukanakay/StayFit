using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StayFit.Application.Features.Queries.Exercises.GetExercisesByWorkoutPlanId
{
    public class GetExercisesByWorkoutPlanIdQueryRequest : IRequest<GetExercisesByWorkoutPlanIdQueryResponse>
    {
        public int WorkoutPlanId { get; set; }
    }
}
