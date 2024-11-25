using StayFit.Application.DTOs.WeeklyProgresses;

namespace StayFit.Application.Features.Queries.WeeklyProgresses.GetWeeklyProgressesBySubsId
{
    public class GetWeeklyProgressesBySubsIdQueryResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public List<GetWeeklyProgressesBySubsIdDto>? GetWeeklyProgressesBySubsIdDtos { get; set; }
    }  
}
