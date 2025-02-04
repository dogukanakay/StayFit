using StayFit.Application.DTOs.WorkoutPlans;

namespace StayFit.Application.Features.Queries.WorkoutPlans.GetWorkoutPlansBySubscriptionId
{
    public class GetWorkoutPlansBySubscriptionIdQueryResponse
    {
        public string Message { get; }
        public bool Success { get; }
        public List<GetWorkoutPlansBySubscriptionIdDto>? GetWorkoutPlansBySubscriptionIdDtos { get; }

        public GetWorkoutPlansBySubscriptionIdQueryResponse(string message, bool success, List<GetWorkoutPlansBySubscriptionIdDto>? getWorkoutPlansBySubscriptionIdDtos)
        {
            Message = message;
            Success = success;
            GetWorkoutPlansBySubscriptionIdDtos = getWorkoutPlansBySubscriptionIdDtos;
        }
    }
}
