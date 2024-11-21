using StayFit.Application.DTOs.WorkoutDays;

namespace StayFit.Application.Features.Queries.WorkoutDays.GetWorkoutDaysByWorkoutPlanId
{
    public class GetWorkoutDaysByWorkoutPlanIdQueryResponse
    {
        public List<GetWorkoutDaysByWorkoutPlanIdDto>? GetWorkoutDaysByWorkoutPlanIdDtos { get; set; }
        public string Message { get; set; }
        public bool Success { get; set; }
    }
}
