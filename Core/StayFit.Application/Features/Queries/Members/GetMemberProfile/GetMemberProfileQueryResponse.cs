using StayFit.Application.DTOs;

namespace StayFit.Application.Features.Queries.Members.GetMemberProfile
{
    public class GetMemberProfileQueryResponse
    {
        public string Message { get; }
        public bool Success { get; }
        public MemberResponseDto? MemberResponseDto { get;}

        public GetMemberProfileQueryResponse(string message, bool success, MemberResponseDto? memberResponseDto)
        {
            Message = message;
            Success = success;
            MemberResponseDto = memberResponseDto;
        }
    }
}
