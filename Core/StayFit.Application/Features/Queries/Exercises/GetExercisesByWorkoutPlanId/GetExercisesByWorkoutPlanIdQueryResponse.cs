using StayFit.Application.DTOs.Exercises;

namespace StayFit.Application.Features.Queries.Exercises.GetExercisesByWorkoutPlanId
{
    public class GetExercisesByWorkoutPlanIdQueryResponse
    {
        public List<GetExercisesByWorkoutPlanIdDto>? GetExercisesByWorkoutPlanIdDtos { get; set; }
        public string Messages { get; set; }
        public bool Success { get; set; }
    }
}
