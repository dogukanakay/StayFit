using AutoMapper;
using MediatR;
using StayFit.Application.Constants.Messages;
using StayFit.Application.Repositories;
using StayFit.Domain.Entities;

namespace StayFit.Application.Features.Commands.WorkoutDays.UpdateWorkoutDay
{
    public class UpdateWorkoutDayCommandHandler : IRequestHandler<UpdateWorkoutDayCommandRequest, UpdateWorkoutDayCommandResponse>
    {
        private readonly IWorkoutDayRepository _workoutDayRepository;
        private readonly IMapper _mapper;

        public UpdateWorkoutDayCommandHandler(IWorkoutDayRepository workoutDayRepository, IMapper mapper)
        {
            _workoutDayRepository = workoutDayRepository;
            _mapper = mapper;
        }

        public async Task<UpdateWorkoutDayCommandResponse> Handle(UpdateWorkoutDayCommandRequest request, CancellationToken cancellationToken)
        {
            WorkoutDay workoutDay = await _workoutDayRepository.GetByIdAsync(request.UpdateWorkoutDayDto.Id);
            if (await _workoutDayRepository.CheckIfWorkoutDayAlreadyExistUpdateAsync(workoutDay.Id, workoutDay.WorkoutPlanId, request.UpdateWorkoutDayDto.DayOfWeek))
                return new(Messages.WorkoutDayAlreadyExist, false);

            _mapper.Map(request.UpdateWorkoutDayDto, workoutDay);

            int result = await _workoutDayRepository.SaveAsync();
            
            return result > 0 ? new(Messages.WorkoutDayUpdatedSuccessful, true) : new(Messages.WorkoutDayUpdateFailed, false);
        }
    }
}
