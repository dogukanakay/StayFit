namespace StayFit.Application.Features.Commands.WeeklyProgresses.CreateWeeklyProgress
{
    public class CreateWeeklyProgressCommandResponse
    {
        public string Message { get; }
        public bool Success { get; }

        public CreateWeeklyProgressCommandResponse(string message, bool success)
        {
            Message = message;
            Success = success;
        }
    }
}
