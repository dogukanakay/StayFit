using StayFit.Application.DTOs.WorkoutPlans;

namespace StayFit.Application.Features.Queries.WorkoutPlans.GetWorkoutPlansBySubscriptionId
{
    public class GetWorkoutPlansBySubscriptionIdQueryResponse
    {
        public List<GetWorkoutPlansBySubscriptionIdDto>? GetWorkoutPlansBySubscriptionIdDtos { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
    }
}
