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
            GetMemberSubscribedTrainerDto getMemberSubscribedTrainerDto = await _subscriptionRepository.GetMemberSubscribedTrainer(request.MemberId);
            if (getMemberSubscribedTrainerDto is null)
                throw new SubscribtionNotFound();
            
            return new() { GetMemberSubscribedTrainerDto = getMemberSubscribedTrainerDto };
        }
    }
}
