using StayFit.Application.DTOs;

namespace StayFit.Application.Features.Queries.Subscriptions.GetMemberSubscribedTrainer
{
    public class GetMemberSubscribedTrainerQueryResponse
    {
        public string Message { get; }
        public bool Success { get; }
        public GetMemberSubscribedTrainerDto? GetMemberSubscribedTrainerDto { get; }

        public GetMemberSubscribedTrainerQueryResponse(string message, bool success, GetMemberSubscribedTrainerDto? getMemberSubscribedTrainerDto)
        {
            Message = message;
            Success = success;
            GetMemberSubscribedTrainerDto = getMemberSubscribedTrainerDto;
        }
    }
}
