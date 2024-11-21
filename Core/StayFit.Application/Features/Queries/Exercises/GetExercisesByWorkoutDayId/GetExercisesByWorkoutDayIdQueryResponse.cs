using StayFit.Application.DTOs.Exercises;

namespace StayFit.Application.Features.Queries.Exercises.GetExercisesByWorkoutDayId
{
    public class GetExercisesByWorkoutDayIdQueryResponse
    {
        public List<GetExercisesByWorkoutDayIdDto>? GetExercisesByWorkoutDayIdDtos { get; set; }
        public string Messages { get; set; }
        public bool Success { get; set; }
    }
}
