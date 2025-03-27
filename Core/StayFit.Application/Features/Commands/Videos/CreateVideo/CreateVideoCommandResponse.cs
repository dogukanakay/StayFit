namespace StayFit.Application.Features.Commands.Videos.CreateVideo
{
    public class CreateVideoCommandResponse
    {
        public string Message { get; }
        public bool Success { get; }

        public CreateVideoCommandResponse(string message, bool success)
        {
            Message = message;
            Success = success;
        }
    }
}
