using AutoMapper;
using MediatR;
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
            if(await _workoutDayRepository.CheckIfWorkoutDayAlreadyExistAsync(request.CreateWorkoutDayDto.WorkoutPlanId, request.CreateWorkoutDayDto.DayOfWeek))
                return new() { Message = "Bu gün zaten mevcut. Aynı gün tekrardan oluşturulamaz", Success = false };

            WorkoutDay workoutDay = _mapper.Map<WorkoutDay>(request.CreateWorkoutDayDto);

            await _workoutDayRepository.AddAsync(workoutDay);

            int result = await _workoutDayRepository.SaveAsync();
            if (result > 0)
                return new() { Message = "Gün başarıyla oluşturuldu", Success = true };
            return new() { Message ="Gün oluşturulurken bir hata ile meydana geldi", Success = false };
        }
    }
}
