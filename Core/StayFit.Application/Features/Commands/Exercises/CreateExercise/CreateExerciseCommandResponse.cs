namespace StayFit.Application.Features.Commands.Exercises.CreateExercise
{
    public class CreateExerciseCommandResponse
    {
        public bool Success { get; }
        public string Message { get; }

        public CreateExerciseCommandResponse(string message, bool success)
        {
            Success = success;
            Message = message;
        }
    }
}
