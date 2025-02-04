using MediatR;
using StayFit.Application.Constants.Messages;
using StayFit.Application.Repositories;
using StayFit.Domain.Entities;

namespace StayFit.Application.Features.Commands.WorkoutDays.DeleteWorkoutDay
{
    public class DeleteWorkoutDayCommandHandler : IRequestHandler<DeleteWorkoutDayCommandRequest, DeleteWorkoutDayCommandResponse>
    {
        private readonly IWorkoutDayRepository _workoutDayRepository;

        public DeleteWorkoutDayCommandHandler(IWorkoutDayRepository workoutDayRepository)
        {
            _workoutDayRepository = workoutDayRepository;
        }

        public async Task<DeleteWorkoutDayCommandResponse> Handle(DeleteWorkoutDayCommandRequest request, CancellationToken cancellationToken)
        {
            WorkoutDay workoutDay = await _workoutDayRepository.GetByIdAsync(request.WorkoutDayId);
            if (workoutDay is null)
                return new(Messages.WorkoutDayNotFound, false);
            await _workoutDayRepository.Remove(workoutDay);
            int result = await _workoutDayRepository.SaveAsync();
           
            return result > 0 ? new(Messages.WorkoutDayDeletedSuccessful, true) : new(Messages.WorkoutDayDeleteFailed, false);
        }
    }
}
