namespace StayFit.Application.Features.Commands.Users.UpdateUserPhoto
{
    public class UpdateUserPhotoCommandResponse
    {
        public string Message { get; }
        public bool Success { get; }

        public UpdateUserPhotoCommandResponse(string message, bool success)
        {
            Message = message;
            Success = success;
        }
    }
}
