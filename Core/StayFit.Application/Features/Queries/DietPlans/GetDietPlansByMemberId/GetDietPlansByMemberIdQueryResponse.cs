using StayFit.Application.DTOs.DietPlans;

namespace StayFit.Application.Features.Queries.DietPlans.GetDietPlansByMemberId
{
    public class GetDietPlansByMemberIdQueryResponse
    {
        public List<GetDietPlansByMemberIdDto>? GetDietPlansByMemberIdDtos { get; set; }
        public string Message { get; set; }
        public bool Success { get; set; }
    }
}
