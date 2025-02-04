using AutoMapper;
using MediatR;
using StayFit.Application.Constants.Messages;
using StayFit.Application.DTOs.Exercises;
using StayFit.Application.Repositories;
using StayFit.Domain.Entities;

namespace StayFit.Application.Features.Queries.Exercises.GetExercisesByWorkoutDayId
{
    public class GetExercisesByWorkoutDayIdQueryHandler : IRequestHandler<GetExercisesByWorkoutDayIdQueryRequest, GetExercisesByWorkoutDayIdQueryResponse>
    {
        private readonly IExerciseRepository _exerciseRepository;
        private readonly IMapper _mapper;

        public GetExercisesByWorkoutDayIdQueryHandler(IExerciseRepository exerciseRepository, IMapper mapper)
        {
            _exerciseRepository = exerciseRepository;
            _mapper = mapper;
        }

        public async Task<GetExercisesByWorkoutDayIdQueryResponse> Handle(GetExercisesByWorkoutDayIdQueryRequest request, CancellationToken cancellationToken)
        {
            List<Exercise> exercises = await _exerciseRepository.GetExercisesByWorkoutDayId(request.WorkoutDayId);
            if (!exercises.Any())
                return new(Messages.ExerciseNotFoundForToday, false, null);

            List<GetExercisesByWorkoutDayIdDto> getExercisesByWorkoutDayIdDtos = _mapper.Map<List<GetExercisesByWorkoutDayIdDto>>(exercises);
            return new(Messages.ExerciseListedSuccessful,true, getExercisesByWorkoutDayIdDtos);


        }
    }
}
