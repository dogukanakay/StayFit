namespace StayFit.Application.Features.Commands.DietDays.UpdateDietDayCompleted
{
    public class UpdateDietDayCompletedCommandResponse
    {
        public string Message { get; }
        public bool Success { get; }

        public UpdateDietDayCompletedCommandResponse(string message, bool success)
        {
            Message = message;
            Success = success;
        }
    }
}
