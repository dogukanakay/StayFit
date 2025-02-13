using MediatR;
using StayFit.Application.Constants.Messages;
using StayFit.Application.Repositories;
using StayFit.Domain.Entities;

namespace StayFit.Application.Features.Commands.DietPlans.DeleteDietPlan
{
    public class DeleteDietPlanCommandHandler : IRequestHandler<DeleteDietPlanCommandRequest, DeleteDietPlanCommandResponse>
    {
        private readonly IDietPlanRepository _dietPlanRepository;

        public DeleteDietPlanCommandHandler(IDietPlanRepository dietPlanRepository)
        {
            _dietPlanRepository = dietPlanRepository;
        }

        public async Task<DeleteDietPlanCommandResponse> Handle(DeleteDietPlanCommandRequest request, CancellationToken cancellationToken)
        {
            DietPlan dietPlan = await _dietPlanRepository.GetByIdAsync(request.DietPlanId);
            if (dietPlan is null)
                return new(Messages.DietPlanNotFoundById, false);
            if (dietPlan.Subscription.TrainerId != request.TrainerId)
                throw new UnauthorizedAccessException();
            
            await _dietPlanRepository.Remove(dietPlan);

            int result = await _dietPlanRepository.SaveAsync();
            return result>0 ? new(Messages.DietPlanDeletedSuccessful, true) : new(Messages.DietPlanDeletedFailed,false);
        }
    }
}
