using AutoMapper;
using MediatR;
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
            List<WorkoutPlan> workoutPlans = await _workoutPlanRepository.GetWhere(wp => wp.SubscriptionId == request.SubscriptionId,tracking: false);
            List<GetWorkoutPlansBySubscriptionIdDto> getWorkoutPlansBySubscriptionIdDtos = _mapper.Map<List<GetWorkoutPlansBySubscriptionIdDto>>(workoutPlans);
            if(workoutPlans is not null)
                return new() { GetWorkoutPlansBySubscriptionIdDtos = getWorkoutPlansBySubscriptionIdDtos, Message = "Abonenin çalışma planı listelendi", Success = true };
            return new() { GetWorkoutPlansBySubscriptionIdDtos = null, Message = "Aboneye tanımlı çalışma planı bulunamadı", Success = false };
        }
    }
}
