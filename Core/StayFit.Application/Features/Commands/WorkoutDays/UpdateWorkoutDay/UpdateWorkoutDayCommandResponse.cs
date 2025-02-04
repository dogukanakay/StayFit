namespace StayFit.Application.Features.Commands.WorkoutDays.UpdateWorkoutDay
{
    public class UpdateWorkoutDayCommandResponse
    {
        public string Message { get; }
        public bool Success { get;  }

        public UpdateWorkoutDayCommandResponse(string message, bool success)
        {
            Message = message;
            Success = success;
        }
    }
}
