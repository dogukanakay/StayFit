using StayFit.Application.DTOs;

namespace StayFit.Application.Features.Commands.Auths.Login.MemberLogin
{
    public class MemberLoginCommandResponse
    {
        public string Message { get; }
        public bool Success { get; }
        public TokenDto? TokenDto { get; }

        public MemberLoginCommandResponse(string message, bool success, TokenDto? tokenDto)
        {
            Message = message;
            Success = success;
            TokenDto = tokenDto;
        }
    }
}
