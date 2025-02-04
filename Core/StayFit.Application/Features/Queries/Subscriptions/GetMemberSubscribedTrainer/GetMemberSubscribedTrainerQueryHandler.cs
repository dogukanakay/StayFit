using AutoMapper;
using MediatR;
using StayFit.Application.Constants.Messages;
using StayFit.Application.DTOs;
using StayFit.Application.Exceptions.Subscriptions;
using StayFit.Application.Repositories;

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
            GetMemberSubscribedTrainerDto getMemberSubscribedTrainerDto = await _subscriptionRepository.GetMemberSubscribedTrainer(request.MemberId);
            if (getMemberSubscribedTrainerDto is null)
                return new(Messages.SubscriptionNotFound, false, null);

            return new(Messages.SubscriptionListedSuccessfuly, true, getMemberSubscribedTrainerDto);
        }
    }
}
