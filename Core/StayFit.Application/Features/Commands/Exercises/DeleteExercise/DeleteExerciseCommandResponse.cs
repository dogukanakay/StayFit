namespace StayFit.Application.Features.Commands.Exercises.DeleteExercise
{
    public class DeleteExerciseCommandResponse
    {
        public string Message { get; }
        public bool Success { get;}

        public DeleteExerciseCommandResponse(string message, bool success)
        {
            Message = message;
            Success = success;
        }
    }
}
