using MediatR;
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
            if (workoutDay == null)
                return new() { Message = "Böyle bir gün bulunamadı.", Success = false };
            await _workoutDayRepository.Remove(workoutDay);
            int result = await _workoutDayRepository.SaveAsync();
            if (result > 0)
                return new() { Message = "Çalışma günü başarıyla silindi.", Success = true };
            return new() { Message = "Çalışma günü silinemedi.", Success = false };
        }
    }
}
