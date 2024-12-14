namespace StayFit.Application.Features.Commands.Auths.Register.MemberRegister
{
    public class MemberRegisterCommandResponse
    {
        public string Message { get; }
        public bool Success { get; }

        public MemberRegisterCommandResponse(string message, bool success)
        {
            Message = message;
            Success = success;
        }
    }
}
