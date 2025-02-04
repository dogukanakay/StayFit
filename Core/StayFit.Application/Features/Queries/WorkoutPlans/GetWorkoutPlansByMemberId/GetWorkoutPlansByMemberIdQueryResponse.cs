using StayFit.Application.DTOs.WorkoutPlans;

namespace StayFit.Application.Features.Queries.WorkoutPlans.GetWorkoutPlansByMemberId
{
    public class GetWorkoutPlansByMemberIdQueryResponse
    {
        public string Message { get; }
        public bool Success { get; }
        public List<GetWorkoutPlansByMemberIdDto>? GetWorkoutPlansByMemberIdDtos { get; }

        public GetWorkoutPlansByMemberIdQueryResponse(string message, bool success, List<GetWorkoutPlansByMemberIdDto>? getWorkoutPlansByMemberIdDtos)
        {
            Message = message;
            Success = success;
            GetWorkoutPlansByMemberIdDtos = getWorkoutPlansByMemberIdDtos;
        }
    }
}
