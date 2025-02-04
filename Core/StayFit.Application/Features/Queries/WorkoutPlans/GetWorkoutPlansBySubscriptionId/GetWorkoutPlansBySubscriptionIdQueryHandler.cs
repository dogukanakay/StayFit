using AutoMapper;
using MediatR;
using StayFit.Application.Constants.Messages;
using StayFit.Application.DTOs.WorkoutPlans;
using StayFit.Application.Repositories;
using StayFit.Domain.Entities;

namespace StayFit.Application.Features.Queries.WorkoutPlans.GetWorkoutPlansBySubscriptionId
{
    public class GetWorkoutPlansBySubscriptionIdQueryHandler : IRequestHandler<GetWorkoutPlansBySubscriptionIdQueryRequest, GetWorkoutPlansBySubscriptionIdQueryResponse>
    {
        private readonly IWorkoutPlanRepository _workoutPlanRepository;
        private readonly IMapper _mapper;

        public GetWorkoutPlansBySubscriptionIdQueryHandler(IWorkoutPlanRepository workoutPlanRepository, IMapper mapper)
        {
            _workoutPlanRepository = workoutPlanRepository;
            _mapper = mapper;
        }

        public async Task<GetWorkoutPlansBySubscriptionIdQueryResponse> Handle(GetWorkoutPlansBySubscriptionIdQueryRequest request, CancellationToken cancellationToken)
        {
            List<WorkoutPlan> workoutPlans = await _workoutPlanRepository.GetWhere(wp => wp.SubscriptionId == request.SubscriptionId, tracking: false);

            if (workoutPlans is null)
                return new(Messages.WorkoutPlanNotFound, false, null);
            List<GetWorkoutPlansBySubscriptionIdDto> getWorkoutPlansBySubscriptionIdDtos = _mapper.Map<List<GetWorkoutPlansBySubscriptionIdDto>>(workoutPlans);
            
            return new(Messages.WorkoutPlanListedSuccessful, true, getWorkoutPlansBySubscriptionIdDtos);
        }
    }
}
