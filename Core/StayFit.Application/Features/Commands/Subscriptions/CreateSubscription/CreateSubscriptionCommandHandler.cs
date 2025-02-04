using AutoMapper;
using MediatR;
using StayFit.Domain.Enums;
using StayFit.Application.Repositories;
using StayFit.Domain.Entities;
using StayFit.Application.Constants.Messages;

namespace StayFit.Application.Features.Commands.Subscriptions.CreateSubscription
{
    public class CreateSubscriptionCommandHandler : IRequestHandler<CreateSubscriptionCommandRequest, CreateSubscriptionCommandResponse>
    {
        private readonly ISubscriptionRepository _subscriptionRepository;
        private readonly ITrainerRepository _trainerRepository;
        private readonly IMapper _mapper;

        public CreateSubscriptionCommandHandler(ISubscriptionRepository subscriptionRepository, IMapper mapper, ITrainerRepository trainerRepository)
        {
            _subscriptionRepository = subscriptionRepository;
            _mapper = mapper;
            _trainerRepository = trainerRepository;
        }

        public async Task<CreateSubscriptionCommandResponse> Handle(CreateSubscriptionCommandRequest request, CancellationToken cancellationToken)
        {
            Subscription subscription = _mapper.Map<Subscription>(request.CreateSubscriptionDto);

            Trainer trainer = await _trainerRepository.GetByIdAsync(subscription.TrainerId);

            subscription.Amount = trainer.MonthlyRate;
            subscription.EndDate = DateTime.UtcNow.AddMonths(1);
            subscription.PaymentStatus = PaymentStatus.Completed;

            await _subscriptionRepository.AddAsync(subscription);
            int result = await _subscriptionRepository.SaveAsync();

            return result > 0 ? new(Messages.SubscriptionCreatedSuccessful, true) : new(Messages.SubscriptionCreatedFailed, false);
        }
    }
}
