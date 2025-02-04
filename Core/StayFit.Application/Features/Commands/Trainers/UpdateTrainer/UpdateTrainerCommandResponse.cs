namespace StayFit.Application.Features.Commands.Trainers.UpdateTrainer
{
    public class UpdateTrainerCommandResponse
    {
        public string Message { get; }
        public bool Success { get; }

        public UpdateTrainerCommandResponse(string message, bool success)
        {
            Message = message;
            Success = success;
        }
    }
}
