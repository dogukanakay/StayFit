namespace StayFit.Application.Features.Commands.DietDays.ResetCompletedDietDays
{
    public class ResetCompletedDietDaysCommandResponse
    {
        public string Message { get;  }
        public bool Success { get;  }

        public ResetCompletedDietDaysCommandResponse(string message, bool success)
        {
            Message = message;
            Success = success;
        }
    }
}
