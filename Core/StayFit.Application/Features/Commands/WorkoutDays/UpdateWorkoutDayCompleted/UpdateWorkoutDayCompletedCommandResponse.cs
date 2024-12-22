namespace StayFit.Application.Features.Commands.WorkoutDays.UpdateWorkoutDayCompleted
{
    public class UpdateWorkoutDayCompletedCommandResponse
    {
        public string Message { get; }
        public bool Success { get; }

        public UpdateWorkoutDayCompletedCommandResponse(string message, bool success)
        {
            Message = message;
            Success = success;
        }
    }
}
