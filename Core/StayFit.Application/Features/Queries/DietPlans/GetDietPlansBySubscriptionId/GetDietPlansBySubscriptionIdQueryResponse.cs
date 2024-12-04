using StayFit.Application.DTOs.DietPlans;

namespace StayFit.Application.Features.Queries.DietPlans.GetDietPlansBySubscriptionId
{
    public class GetDietPlansBySubscriptionIdQueryResponse
    {
        public List<GetDietPlansBySubscriptionIdDto>? GetDietPlansBySubscriptionIdDtos { get; set; }
        public string Message { get; set; }
        public bool Success { get; set; }
    }
}
