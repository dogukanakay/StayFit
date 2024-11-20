using AutoMapper;
using MediatR;
using StayFit.Application.DTOs.Exercises;
using StayFit.Application.Repositories;
using StayFit.Domain.Entities;

namespace StayFit.Application.Features.Queries.Exercises.GetExercisesByWorkoutPlanId
{
    public class GetExercisesByWorkoutPlanIdQueryHandler : IRequestHandler<GetExercisesByWorkoutPlanIdQueryRequest, GetExercisesByWorkoutPlanIdQueryResponse>
    {
        private readonly IExerciseRepository _exerciseRepository;
        private readonly IMapper _mapper;

        public GetExercisesByWorkoutPlanIdQueryHandler(IExerciseRepository exerciseRepository, IMapper mapper)
        {
            _exerciseRepository = exerciseRepository;
            _mapper = mapper;
        }

        public async Task<GetExercisesByWorkoutPlanIdQueryResponse> Handle(GetExercisesByWorkoutPlanIdQueryRequest request, CancellationToken cancellationToken)
        {
            List<Exercise> exercises = await _exerciseRepository.GetExercisesByWorkoutPlanId(request.WorkoutPlanId);
            if (exercises.Any())
            {
                List<GetExercisesByWorkoutPlanIdDto> getExercisesByWorkoutPlanIdDtos = await Task.Run(() =>
                 exercises.Select(e => new GetExercisesByWorkoutPlanIdDto
                 {
                     ExerciseId = e.Id,
                     WorkoutDayId = e.WorkoutDayId,
                     Day = e.WorkoutDay.Day,
                     Description = e.Description,
                     DurationMinutes = e.DurationMinutes,
                     ExerciseCategory = e.ExerciseCategory,
                     ExerciseLevel = e.ExerciseLevel,
                     IsCompleted = e.WorkoutDay.IsCompleted,
                     Name = e.Name,
                     RepetitionCount = e.RepetitionCount,
                     SetCount = e.SetCount
                 }).ToList()
                );
                return new() { GetExercisesByWorkoutPlanIdDtos = getExercisesByWorkoutPlanIdDtos, Success = true, Messages = "Bu plana ait egzersizler başarı ile getirildi." };
            }
            return new() { Success = false, Messages = "Egzersiz bilgileri getirilemedi." };
        }
    }
}
