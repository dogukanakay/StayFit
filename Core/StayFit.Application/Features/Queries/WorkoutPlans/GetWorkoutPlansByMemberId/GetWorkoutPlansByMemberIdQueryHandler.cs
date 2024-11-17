using AutoMapper;
using MediatR;
using StayFit.Application.DTOs.WorkoutPlans;
using StayFit.Application.Repositories;
using StayFit.Domain.Entities;

namespace StayFit.Application.Features.Queries.WorkoutPlans.GetWorkoutPlansByMemberId
{
    public class GetWorkoutPlansByMemberIdQueryHandler : IRequestHandler<GetWorkoutPlansByMemberIdQueryRequest, GetWorkoutPlansByMemberIdQueryResponse>
    {
        private readonly IWorkoutPlanRepository _workoutPlanRepository;
        private readonly IMapper _mapper;

        public GetWorkoutPlansByMemberIdQueryHandler(IWorkoutPlanRepository workoutPlanRepository, IMapper mapper)
        {
            _workoutPlanRepository = workoutPlanRepository;
            _mapper = mapper;
        }

        public async Task<GetWorkoutPlansByMemberIdQueryResponse> Handle(GetWorkoutPlansByMemberIdQueryRequest request, CancellationToken cancellationToken)
        {
            List<WorkoutPlan> workoutPlans = await _workoutPlanRepository.GetWhere(wp => wp.MemberId == request.MemberId, tracking:false);
            List<GetWorkoutPlansByMemberIdDto> getWorkoutPlansByMemberIdDtos = _mapper.Map<List<GetWorkoutPlansByMemberIdDto>>(workoutPlans);

            if (workoutPlans is not null)
                return new() { GetWorkoutPlansByMemberIdDtos = getWorkoutPlansByMemberIdDtos, Success = true, Message = "Çalışma planları listelendi." };
            return new() { GetWorkoutPlansByMemberIdDtos = null, Message ="Çalışma planı bulunamadı", Success = false };
        }
    }
}
