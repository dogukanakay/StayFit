namespace StayFit.Application.Features.Commands.Auths.Password
{
    public class UpdatePasswordCommandResponse
    {
        public bool Success { get; }
        public string Message { get;  }

        public UpdatePasswordCommandResponse(bool success, string message)
        {
            Success = success;
            Message = message;
        }
    }
}
