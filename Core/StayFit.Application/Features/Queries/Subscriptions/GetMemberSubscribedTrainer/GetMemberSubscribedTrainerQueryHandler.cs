using AutoMapper;
using MediatR;
using StayFit.Application.DTOs;
using StayFit.Application.Exceptions;
using StayFit.Application.Repositories;
using StayFit.Domain.Entities;

namespace StayFit.Application.Features.Queries.Subscriptions.GetMemberSubscribedTrainer
{
    public class GetMemberSubscribedTrainerQueryHandler : IRequestHandler<GetMemberSubscribedTrainerQueryRequest, GetMemberSubscribedTrainerQueryResponse>
    {
        private readonly ISubscriptionRepository _subscriptionRepository;
        private readonly IMapper _mapper;

        public GetMemberSubscribedTrainerQueryHandler(ISubscriptionRepository subscriptionRepository, IMapper mapper)
        {
            _subscriptionRepository = subscriptionRepository;
            _mapper = mapper;
        }

        public async Task<GetMemberSubscribedTrainerQueryResponse> Handle(GetMemberSubscribedTrainerQueryRequest request, CancellationToken cancellationToken)
        {
            Subscription subscription = await _subscriptionRepository.GetMemberSubscribedTrainer(request.MemberId);
            if (subscription == null)
                throw new SubscribtionNotFound();
            GetMemberSubscribedTrainerDto getMemberSubscribedTrainerDto = _mapper.Map<GetMemberSubscribedTrainerDto>(subscription);

            return new() { GetMemberSubscribedTrainerDto = getMemberSubscribedTrainerDto };
        }
    }
}
