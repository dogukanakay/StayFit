namespace StayFit.Application.Features.Commands.Diets.UpdateDietByAI
{
    public class UpdateDietByAICommandResponse
    {
        public string Message { get;}
        public bool Success { get;}

        public UpdateDietByAICommandResponse(string message, bool success)
        {
            Message = message;
            Success = success;
        }
    }
}
