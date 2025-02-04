using AutoMapper;
using MediatR;
using StayFit.Application.Constants.Messages;
using StayFit.Application.Repositories;
using StayFit.Domain.Entities;

namespace StayFit.Application.Features.Commands.WorkoutDays.CreateWorkoutDay
{
    public class CreateWorkoutDayCommandHandler : IRequestHandler<CreateWorkoutDayCommandRequest, CreateWorkoutDayCommandResponse>
    {
        private readonly IWorkoutDayRepository _workoutDayRepository;
        private readonly IMapper _mapper;

        public CreateWorkoutDayCommandHandler(IWorkoutDayRepository workoutDayRepository, IMapper mapper)
        {
            _workoutDayRepository = workoutDayRepository;
            _mapper = mapper;
        }

        public async Task<CreateWorkoutDayCommandResponse> Handle(CreateWorkoutDayCommandRequest request, CancellationToken cancellationToken)
        {
            if (await _workoutDayRepository.CheckIfWorkoutDayAlreadyExistAsync(request.CreateWorkoutDayDto.WorkoutPlanId, request.CreateWorkoutDayDto.DayOfWeek))
                return new(Messages.WorkoutDayAlreadyExist, false);

            WorkoutDay workoutDay = _mapper.Map<WorkoutDay>(request.CreateWorkoutDayDto);

            await _workoutDayRepository.AddAsync(workoutDay);

            int result = await _workoutDayRepository.SaveAsync();
            
            return result > 0 ? new(Messages.WorkoutDayCreatedSuccessful, true) : new(Messages.WorkoutDayCreateFailed, false);
        }
    }
}
