using StayFit.Application.DTOs.Diets;

namespace StayFit.Application.Features.Queries.Diets.GetDietsByDietDayId
{
    public class GetDietsByDietDayIdQueryResponse
    {
        public List<GetDietsByDietDayIdDto>? GetDietsByDietDayIdDtos { get; set; }
        public string Message { get; set; }
        public bool Success { get; set; }

        public GetDietsByDietDayIdQueryResponse(List<GetDietsByDietDayIdDto>? getDietsByDietDayIdDtos, string message, bool success)
        {
            GetDietsByDietDayIdDtos = getDietsByDietDayIdDtos;
            Message = message;
            Success = success;
        }
    }
}
