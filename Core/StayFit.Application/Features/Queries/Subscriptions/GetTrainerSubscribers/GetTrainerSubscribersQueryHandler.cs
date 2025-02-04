using AutoMapper;
using MediatR;
using StayFit.Application.Constants.Messages;
using StayFit.Application.DTOs;
using StayFit.Application.Repositories;
using StayFit.Domain.Entities;

namespace StayFit.Application.Features.Queries.Subscriptions.GetTrainerSubscribers
{
    public class GetTrainerSubscribersQueryHandler : IRequestHandler<GetTrainerSubscribersQueryRequest, GetTrainerSubscribersQueryResponse>
    {
        ISubscriptionRepository _subscriptionRepository;
        IMapper _mapper;

        public GetTrainerSubscribersQueryHandler(ISubscriptionRepository subscriptionRepository, IMapper mapper)
        {
            _subscriptionRepository = subscriptionRepository;
            _mapper = mapper;
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
