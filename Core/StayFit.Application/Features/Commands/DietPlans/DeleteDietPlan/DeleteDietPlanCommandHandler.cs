using MediatR;
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
            if (dietPlan == null)
                return new("Bu id'ye ait bir diyet planı bulunamadı", false);
            
            await _dietPlanRepository.Remove(dietPlan);

            int result = await _dietPlanRepository.SaveAsync();
            return result>0 ? new("Diyet planı başarıyla silindi.", true) : new("Diyet planı silinirken bir sorun oluştu.",false);
        }
    }
}
