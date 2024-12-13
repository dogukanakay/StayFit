using StayFit.Application.DTOs;

namespace StayFit.Application.Features.Commands.Auths.Login.TrainerLogin
{
    public class TrainerLoginCommandResponse
    {
        public string Message { get; }
        public bool Success { get; }
        public TokenDto? TokenDto { get; }

        public TrainerLoginCommandResponse(string message, bool success)
        {
            Message = message;
            Success = success;
        }

        public TrainerLoginCommandResponse(string message, bool success, TokenDto? tokenDto)
        {
            Message = message;
            Success = success;
            TokenDto = tokenDto;
        }
    }
}
