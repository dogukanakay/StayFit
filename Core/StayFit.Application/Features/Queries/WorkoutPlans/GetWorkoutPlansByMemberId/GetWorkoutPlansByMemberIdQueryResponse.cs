using StayFit.Application.DTOs.WorkoutPlans;

namespace StayFit.Application.Features.Queries.WorkoutPlans.GetWorkoutPlansByMemberId
{
    public class GetWorkoutPlansByMemberIdQueryResponse
    {
        public List<GetWorkoutPlansByMemberIdDto>? GetWorkoutPlansByMemberIdDtos { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
    }
}
