using AutoMapper;
using MediatR;
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
            List<Subscription> subscriptions = await _subscriptionRepository.GetTrainerSubscribers(request.TrainerId);
            List<GetTrainerSubscribersDto> getTrainerSubscribersDtos = _mapper.Map<List<GetTrainerSubscribersDto>>(subscriptions);

            return new() { GetTrainerSubscribersDtos = getTrainerSubscribersDtos };
        }
    }
}
