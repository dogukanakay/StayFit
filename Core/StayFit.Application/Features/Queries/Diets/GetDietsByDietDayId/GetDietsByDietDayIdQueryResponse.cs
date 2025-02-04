using StayFit.Application.DTOs.Diets;

namespace StayFit.Application.Features.Queries.Diets.GetDietsByDietDayId
{
    public class GetDietsByDietDayIdQueryResponse
    {
        
        public string Message { get; }
        public bool Success { get;  }
        public List<GetDietsByDietDayIdDto>? GetDietsByDietDayIdDtos { get; }

        public GetDietsByDietDayIdQueryResponse(string message, bool success, List<GetDietsByDietDayIdDto>? getDietsByDietDayIdDtos)
        {
            Message = message;
            Success = success;
            GetDietsByDietDayIdDtos = getDietsByDietDayIdDtos;
        }
    }
}
