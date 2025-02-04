using StayFit.Application.DTOs;

namespace StayFit.Application.Features.Queries.Subscriptions.GetTrainerSubscribers
{
    public class GetTrainerSubscribersQueryResponse
    {
        public string Message { get; }
        public bool Success { get; }
        public List<GetTrainerSubscribersDto>? GetTrainerSubscribersDtos { get; }

        public GetTrainerSubscribersQueryResponse(string message, bool success, List<GetTrainerSubscribersDto>? getTrainerSubscribersDtos)
        {
            Message = message;
            Success = success;
            GetTrainerSubscribersDtos = getTrainerSubscribersDtos;
        }
    }
}
