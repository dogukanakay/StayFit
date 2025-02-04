namespace StayFit.Application.Features.Commands.WorkoutDays.DeleteWorkoutDay
{
    public class DeleteWorkoutDayCommandResponse
    {
        public string Message { get; }
        public bool Success { get; }

        public DeleteWorkoutDayCommandResponse(string message, bool success)
        {
            Message = message;
            Success = success;
        }
    }
}
