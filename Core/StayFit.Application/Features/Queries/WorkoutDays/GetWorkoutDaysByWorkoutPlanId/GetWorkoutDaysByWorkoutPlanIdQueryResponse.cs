using StayFit.Application.DTOs.WorkoutDays;

namespace StayFit.Application.Features.Queries.WorkoutDays.GetWorkoutDaysByWorkoutPlanId
{
    public class GetWorkoutDaysByWorkoutPlanIdQueryResponse
    {

        public string Message { get; }
        public bool Success { get; }
        public List<GetWorkoutDaysByWorkoutPlanIdDto>? GetWorkoutDaysByWorkoutPlanIdDtos { get; }

        public GetWorkoutDaysByWorkoutPlanIdQueryResponse(string message, bool success, List<GetWorkoutDaysByWorkoutPlanIdDto>? getWorkoutDaysByWorkoutPlanIdDtos)
        {
            Message = message;
            Success = success;
            GetWorkoutDaysByWorkoutPlanIdDtos = getWorkoutDaysByWorkoutPlanIdDtos;
        }
    }
}
