using StayFit.Application.DTOs.WeeklyProgresses;

namespace StayFit.Application.Features.Queries.WeeklyProgresses.GetWeeklyProgressesBySubsId
{
    public class GetWeeklyProgressesBySubsIdQueryResponse
    {
        public string Message { get; }
        public bool Success { get; }
        public List<GetWeeklyProgressesBySubsIdDto>? GetWeeklyProgressesBySubsIdDtos { get; }

        public GetWeeklyProgressesBySubsIdQueryResponse(string message, bool success, List<GetWeeklyProgressesBySubsIdDto>? getWeeklyProgressesBySubsIdDtos)
        {
            Message = message;
            Success = success;
            GetWeeklyProgressesBySubsIdDtos = getWeeklyProgressesBySubsIdDtos;
        }
    }  
}
