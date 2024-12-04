namespace StayFit.Application.Features.Commands.Diets.DeleteDiet
{
    public class DeleteDietCommandResponse
    {
        public string Message { get; }
        public bool Success { get; }

        public DeleteDietCommandResponse(string message, bool success)
        {
            Message = message;
            Success = success;
        }
    }
}
