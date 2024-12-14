namespace StayFit.Application.Features.Commands.Auths.Register.TrainerRegister
{
    public class TrainerRegisterCommandResponse
    {
        public string Message { get;}
        public bool Success { get;}

        public TrainerRegisterCommandResponse(string message, bool success)
        {
            Message = message;
            Success = success;
        }
    }

}
