namespace StayFit.Application.Features.Commands.WorkoutDays.CreateWorkoutDay
{
    public class CreateWorkoutDayCommandResponse
    {
        public string Message { get; }
        public bool Success { get; }

        public CreateWorkoutDayCommandResponse(string message, bool success)
        {
            Message = message;
            Success = success;
        }
    }
}
