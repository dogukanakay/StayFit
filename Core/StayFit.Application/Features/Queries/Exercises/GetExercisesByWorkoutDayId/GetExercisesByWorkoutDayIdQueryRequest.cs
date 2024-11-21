using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StayFit.Application.Features.Queries.Exercises.GetExercisesByWorkoutDayId
{
    public class GetExercisesByWorkoutDayIdQueryRequest : IRequest<GetExercisesByWorkoutDayIdQueryResponse>
    {
        public int WorkoutDayId { get; set; }
    }
}
