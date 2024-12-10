using AutoMapper;
using MediatR;
using StayFit.Application.DTOs.Exercises;
using StayFit.Application.Repositories;
using StayFit.Domain.Entities;

namespace StayFit.Application.Features.Queries.Exercises.GetTodaysExercisesByMemberId
{
    public class GetTodaysExercisesByMemberIdQueryHandler : IRequestHandler<GetTodaysExercisesByMemberIdQueryRequest, GetTodaysExercisesByMemberIdQueryResponse>
    {
        private readonly IExerciseRepository _exerciseRepository;
        private readonly IMapper _mapper;

        public GetTodaysExercisesByMemberIdQueryHandler(IExerciseRepository exerciseRepository, IMapper mapper)
        {
            _exerciseRepository = exerciseRepository;
            _mapper = mapper;
        }

        public async Task<GetTodaysExercisesByMemberIdQueryResponse> Handle(GetTodaysExercisesByMemberIdQueryRequest request, CancellationToken cancellationToken)
        {
            List<Exercise> exercises = await _exerciseRepository.GetTodaysExercisesAsync(request.MemberId);
            if (exercises is null) return new("Bugüne ait bir egzersiz bulunmamakta.", false);

            List<GetTodaysExercisesDto> getTodaysExercisesDtos = _mapper.Map<List<GetTodaysExercisesDto>>(exercises);
            return new("Bugüne ait egzersiz listesi listelendi.", true, getTodaysExercisesDtos);
        }
    }
}
