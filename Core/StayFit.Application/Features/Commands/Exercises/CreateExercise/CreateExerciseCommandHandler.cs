using AutoMapper;
using MediatR;
using StayFit.Application.Repositories;
using StayFit.Domain.Entities;

namespace StayFit.Application.Features.Commands.Exercises.CreateExercise
{
    public class CreateExerciseCommandHandler : IRequestHandler<CreateExerciseCommandRequest, CreateExerciseCommandResponse>
    {
        private readonly IExerciseRepository _exerciseRepository;
        private readonly IWorkoutDayRepository _workoutDayRepository;
        private readonly IMapper _mapper;

        public CreateExerciseCommandHandler(IExerciseRepository exerciseRepository, IWorkoutDayRepository workoutDayRepository, IMapper mapper)
        {
            _exerciseRepository = exerciseRepository;
            _workoutDayRepository = workoutDayRepository;
            _mapper = mapper;
        }

        public async Task<CreateExerciseCommandResponse> Handle(CreateExerciseCommandRequest request, CancellationToken cancellationToken)
        {

            List<Exercise> exercises = _mapper.Map<List<Exercise>>(request.CreateExerciseDtos);
            await _exerciseRepository.AddRangeAsync(exercises);
            int result = await _exerciseRepository.SaveAsync();
            if (result > 0)
                return new() { Message = "Egzersiz başarıyla oluşturuldu.", Success = true };
            return new() { Message = "Egzersiz oluştururken bir hatayla karşılaşıldı.", Success = false };

        }
    }
}
