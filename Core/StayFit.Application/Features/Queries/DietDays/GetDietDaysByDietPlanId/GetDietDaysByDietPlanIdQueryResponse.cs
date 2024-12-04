using StayFit.Application.DTOs.DietDays;

namespace StayFit.Application.Features.Queries.DietDays.GetDietDaysByDietPlanId
{
    public class GetDietDaysByDietPlanIdQueryResponse
    {
        public string Message { get;}
        public bool Success { get;}
        public List<GetDietDaysByDietPlanIdDto>? GetDietDaysByDietPlanDtos { get;}

        public GetDietDaysByDietPlanIdQueryResponse(string message, bool success, List<GetDietDaysByDietPlanIdDto>? getDietDaysByDietPlanDtos)
        {
            Message = message;
            Success = success;
            GetDietDaysByDietPlanDtos = getDietDaysByDietPlanDtos;
        }
    }
}
