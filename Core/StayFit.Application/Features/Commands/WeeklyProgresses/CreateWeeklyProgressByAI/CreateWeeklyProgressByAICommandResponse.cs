namespace StayFit.Application.Features.Commands.WeeklyProgresses.CreateWeeklyProgressByAI
{
    public class CreateWeeklyProgressByAICommandResponse
    {
        public string Message { get; }
        public bool Success { get; }

        public CreateWeeklyProgressByAICommandResponse(string message, bool success)
        {
            Message = message;
            Success = success;
        }
    }
}
