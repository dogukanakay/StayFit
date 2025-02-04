namespace StayFit.Application.Features.Commands.Members.UpdateMember
{
    public class UpdateMemberCommandResponse
    {
        public string Message { get; }
        public bool Success { get; }

        public UpdateMemberCommandResponse(string message, bool success)
        {
            Message = message;
            Success = success;
        }
    }
}
