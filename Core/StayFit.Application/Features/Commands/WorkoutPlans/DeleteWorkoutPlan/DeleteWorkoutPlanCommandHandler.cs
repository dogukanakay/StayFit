using MediatR;
using StayFit.Application.Constants.Messages;
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
                return new(Messages.WorkoutPlanNotFoundById, false);
            await _workoutPlanRepository.Remove(workoutPlan);
            int result = await _workoutPlanRepository.SaveAsync();

            return result > 0 ? new(Messages.WorkoutPlanDeletedSuccessful, true) : new(Messages.WorkoutPlanDeleteFailed, false);

        }
    }
}
