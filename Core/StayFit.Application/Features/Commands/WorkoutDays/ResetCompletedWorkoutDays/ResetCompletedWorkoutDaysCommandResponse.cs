namespace StayFit.Application.Features.Commands.WorkoutDays.ResetCompletedWorkoutDays
{
    public class ResetCompletedWorkoutDaysCommandResponse
    {
        public string Message { get; }
        public bool Success { get; }

        public ResetCompletedWorkoutDaysCommandResponse(string message, bool success)
        {
            Message = message;
            Success = success;
        }
    }
}
