using MediatR;
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
            if(!await _workoutDayRepository.CheckIfMemberHasThisWorkoutDay(request.WorkoutDayId,request.MemberId))
                throw new UnauthorizedAccessException();

            WorkoutDay workoutDay  = await _workoutDayRepository.GetByIdAsync(request.WorkoutDayId);
            workoutDay.IsCompleted = true;

            int result = await _workoutDayRepository.SaveAsync();

            return result > 1 ? new("Günün egzersizi tamamlandı olarak işaretlendi.", true) : new("İşlem başarısız", false);
        }
    }
}
