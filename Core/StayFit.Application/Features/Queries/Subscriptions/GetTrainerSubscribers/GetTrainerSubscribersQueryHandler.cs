using MediatR;
using StayFit.Application.Constants.Messages;
using StayFit.Application.DTOs;
using StayFit.Application.Repositories;

namespace StayFit.Application.Features.Queries.Subscriptions.GetTrainerSubscribers
{
    public class GetTrainerSubscribersQueryHandler : IRequestHandler<GetTrainerSubscribersQueryRequest, GetTrainerSubscribersQueryResponse>
    {
        ISubscriptionRepository _subscriptionRepository;

        public GetTrainerSubscribersQueryHandler(ISubscriptionRepository subscriptionRepository)
        {
            _subscriptionRepository = subscriptionRepository;
        }

        public async Task<GetTrainerSubscribersQueryResponse> Handle(GetTrainerSubscribersQueryRequest request, CancellationToken cancellationToken)
        {
            
            List<GetTrainerSubscribersDto> getTrainerSubscribersDtos = await _subscriptionRepository.GetTrainerSubscribers(request.TrainerId);
            if (getTrainerSubscribersDtos is null)
                return new(Messages.SubscriptionNotFound, false, null);

            return new(Messages.SubscriptionListedSuccessfuly, true, getTrainerSubscribersDtos);
        }
    }
}
