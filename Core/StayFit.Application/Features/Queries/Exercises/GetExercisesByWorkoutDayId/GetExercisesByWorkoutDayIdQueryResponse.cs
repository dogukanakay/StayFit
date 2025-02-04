using StayFit.Application.DTOs.Exercises;

namespace StayFit.Application.Features.Queries.Exercises.GetExercisesByWorkoutDayId
{
    public class GetExercisesByWorkoutDayIdQueryResponse
    {
        
        public string Messages { get; }
        public bool Success { get; }
        public List<GetExercisesByWorkoutDayIdDto>? GetExercisesByWorkoutDayIdDtos { get; }

        public GetExercisesByWorkoutDayIdQueryResponse(string messages, bool success, List<GetExercisesByWorkoutDayIdDto>? getExercisesByWorkoutDayIdDtos)
        {
            Messages = messages;
            Success = success;
            GetExercisesByWorkoutDayIdDtos = getExercisesByWorkoutDayIdDtos;
        }
    }
}
