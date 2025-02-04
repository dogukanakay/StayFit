namespace StayFit.Application.Features.Commands.DietDays.CreateDietDay
{
    public class CreateDietDayCommandResponse
    {
        public string Message { get;}
        public bool Success { get; }

        public CreateDietDayCommandResponse(string message, bool success)
        {
            Message = message;
            Success = success;
        }
    }
}
