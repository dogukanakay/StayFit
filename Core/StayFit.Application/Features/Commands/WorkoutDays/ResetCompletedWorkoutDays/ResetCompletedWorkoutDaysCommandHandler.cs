using MediatR;
using StayFit.Application.Constants.Messages;
using StayFit.Application.Repositories;

namespace StayFit.Application.Features.Commands.WorkoutDays.ResetCompletedWorkoutDays
{
    public class ResetCompletedWorkoutDaysCommandHandler : IRequestHandler<ResetCompletedWorkoutDaysCommandRequest, ResetCompletedWorkoutDaysCommandResponse>
    {
        private readonly IWorkoutDayRepository _workoutDayRepository;

        public ResetCompletedWorkoutDaysCommandHandler(IWorkoutDayRepository workoutDayRepository)
        {
            _workoutDayRepository = workoutDayRepository;
        }

        public async Task<ResetCompletedWorkoutDaysCommandResponse> Handle(ResetCompletedWorkoutDaysCommandRequest request, CancellationToken cancellationToken)
        {
            int countOfResetedWorkoutDay = await _workoutDayRepository.ResetCompletedWorkoutDaysAsync();

            if (countOfResetedWorkoutDay > 0)
                return new($"{countOfResetedWorkoutDay} {Messages.WorkoutDaysResetedSuccesfuly}", true);
            return new(Messages.WorkoutDaysReseteFailed, false);
        }
    }
}
