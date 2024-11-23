using MediatR;
using StayFit.Application.Repositories;
using StayFit.Domain.Entities;

namespace StayFit.Application.Features.Commands.WorkoutPlans.DeleteWorkoutPlan
{
    public class DeleteWorkoutPlanCommandHandler : IRequestHandler<DeleteWorkoutPlanCommandRequest, DeleteWorkoutPlanCommandResponse>
    {
        private readonly IWorkoutPlanRepository _workoutPlanRepository;

        public DeleteWorkoutPlanCommandHandler(IWorkoutPlanRepository workoutPlanRepository)
        {
            _workoutPlanRepository = workoutPlanRepository;
        }

        public async Task<DeleteWorkoutPlanCommandResponse> Handle(DeleteWorkoutPlanCommandRequest request, CancellationToken cancellationToken)
        {
            WorkoutPlan workoutPlan = await _workoutPlanRepository.GetByIdAsync(request.WorkoutPlanId, false);
            if (workoutPlan == null)
                return new() { Message = "Bu id için kayıtlı bir plan bulunamadı.", Success = false };
            await _workoutPlanRepository.Remove(workoutPlan);
            int result = await _workoutPlanRepository.SaveAsync();

            if (result == 0)
                return new() { Message = "Bu plan silinirken bir hata ile karşılaşıldı.", Success = false };
            return new() { Message = "Plan başarıyla silindi", Success = true };

        }
    }
}
