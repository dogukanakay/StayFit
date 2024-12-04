namespace StayFit.Application.Features.Commands.Diets.CreateDiet
{
    public class CreateDietCommandResponse
    {
        public string Message { get;}
        public bool Success { get;}

        public CreateDietCommandResponse(string message, bool success)
        {
            Message = message;
            Success = success;
        }
    }
}
