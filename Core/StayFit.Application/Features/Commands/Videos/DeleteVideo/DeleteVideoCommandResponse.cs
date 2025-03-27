namespace StayFit.Application.Features.Commands.Videos.DeleteVideo
{
    public class DeleteVideoCommandResponse
    {
        public string Message { get;}
        public bool Success { get; }

        public DeleteVideoCommandResponse(string message, bool success)
        {
            Message = message;
            Success = success;
        }
    }
}
