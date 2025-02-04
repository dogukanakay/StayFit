namespace StayFit.Application.Features.Commands.DietDays.DeleteDietDay
{
    public class DeleteDietDayCommandResponse
    {
        public string Message { get; }
        public bool Success { get;  }

        public DeleteDietDayCommandResponse(string message, bool success)
        {
            Message = message;
            Success = success;
        }
    }
}
