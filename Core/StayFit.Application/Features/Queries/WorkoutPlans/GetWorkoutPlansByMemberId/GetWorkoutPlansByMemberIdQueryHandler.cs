using AutoMapper;
using MediatR;
using StayFit.Application.Constants.Messages;
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
            List<WorkoutPlan> workoutPlans = await _workoutPlanRepository.GetWhere(wp => wp.MemberId == request.MemberId, tracking: false);

            if (workoutPlans is null)
                return new(Messages.WorkoutPlanNotFound, false, null);


            List<GetWorkoutPlansByMemberIdDto> getWorkoutPlansByMemberIdDtos = _mapper.Map<List<GetWorkoutPlansByMemberIdDto>>(workoutPlans);

            return new(Messages.WorkoutPlanListedSuccessful, true,  getWorkoutPlansByMemberIdDtos);
        }
    }
}
