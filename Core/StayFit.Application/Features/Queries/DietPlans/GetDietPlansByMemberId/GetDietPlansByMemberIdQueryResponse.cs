using StayFit.Application.DTOs.DietPlans;

namespace StayFit.Application.Features.Queries.DietPlans.GetDietPlansByMemberId
{
    public class GetDietPlansByMemberIdQueryResponse
    {

        public string Message { get; }
        public bool Success { get; }
        public List<GetDietPlansByMemberIdDto>? GetDietPlansByMemberIdDtos { get; }
        public GetDietPlansByMemberIdQueryResponse(string message, bool success, List<GetDietPlansByMemberIdDto>? getDietPlansByMemberIdDtos)
        {
            GetDietPlansByMemberIdDtos = getDietPlansByMemberIdDtos;
            Message = message;
            Success = success;
        }
    }
}
