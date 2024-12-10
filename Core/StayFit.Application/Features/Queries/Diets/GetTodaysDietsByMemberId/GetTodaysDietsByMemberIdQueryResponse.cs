using StayFit.Application.DTOs.Diets;

namespace StayFit.Application.Features.Queries.Diets.GetTodaysDietsByMemberId
{
    public class GetTodaysDietsByMemberIdQueryResponse
    {
        public string Message { get; }
        public bool Success { get; }
        public List<GetTodaysDietsDto>? GetTodaysDietsDtos { get; }

        public GetTodaysDietsByMemberIdQueryResponse(string message, bool success, List<GetTodaysDietsDto>? getTodaysDietsDtos)
        {
            Message = message;
            Success = success;
            GetTodaysDietsDtos = getTodaysDietsDtos;
        }
    }
}
