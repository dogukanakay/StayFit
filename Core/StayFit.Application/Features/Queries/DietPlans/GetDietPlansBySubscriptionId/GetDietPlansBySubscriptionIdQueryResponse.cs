using StayFit.Application.DTOs.DietPlans;

namespace StayFit.Application.Features.Queries.DietPlans.GetDietPlansBySubscriptionId
{
    public class GetDietPlansBySubscriptionIdQueryResponse
    {

        public string Message { get;  }
        public bool Success { get;  }
        public List<GetDietPlansBySubscriptionIdDto>? GetDietPlansBySubscriptionIdDtos { get; }

        public GetDietPlansBySubscriptionIdQueryResponse(string message, bool success, List<GetDietPlansBySubscriptionIdDto>? getDietPlansBySubscriptionIdDtos)
        {
            Message = message;
            Success = success;
            GetDietPlansBySubscriptionIdDtos = getDietPlansBySubscriptionIdDtos;
        }
    }
}
