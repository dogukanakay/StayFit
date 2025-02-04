using MediatR;
using StayFit.Application.Constants.Messages;
using StayFit.Application.Repositories;
using StayFit.Domain.Entities;

namespace StayFit.Application.Features.Commands.WorkoutDays.UpdateWorkoutDayCompleted
{
    public class UpdateWorkoutDayCompletedCommandHandler : IRequestHandler<UpdateWorkoutDayCompletedCommandRequest, UpdateWorkoutDayCompletedCommandResponse>
    {
        private readonly IWorkoutDayRepository _workoutDayRepository;

        public UpdateWorkoutDayCompletedCommandHandler(IWorkoutDayRepository workoutDayRepository
            )
        {
            _workoutDayRepository = workoutDayRepository;
        }

        public async Task<UpdateWorkoutDayCompletedCommandResponse> Handle(UpdateWorkoutDayCompletedCommandRequest request, CancellationToken cancellationToken)
        {
            WorkoutDay workoutDay = await _workoutDayRepository
                .GetSingleAsync(wD => wD.Id == request.WorkoutDayId && wD.WorkoutPlan.MemberId == request.MemberId && wD.DayOfWeek == DateTime.Today.DayOfWeek);

            if (workoutDay is null)
                return new(Messages.WorkoutDayCannotCompleted, false);

            workoutDay.IsCompleted = true;

            int result = await _workoutDayRepository.SaveAsync();

            return result > 0 ? new(Messages.WorkoutDayComletedSuccessful, true) : new(Messages.WorkoutDayComleteFailed, false);
        }
    }
}
