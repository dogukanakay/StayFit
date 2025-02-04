using StayFit.Application.DTOs;

namespace StayFit.Application.Features.Commands.Subscriptions.CreateSubscription
{
    public class CreateSubscriptionCommandResponse
    {
        public string Message { get;}
        public bool Success { get; }

        public CreateSubscriptionCommandResponse(string message, bool success)
        {
            Message = message;
            Success = success;
        }
    }
}
