using AutoMapper;
using MediatR;
using StayFit.Application.Constants.Messages;
using StayFit.Application.DTOs.DietPlans;
using StayFit.Application.Repositories;
using StayFit.Domain.Entities;

namespace StayFit.Application.Features.Queries.DietPlans.GetDietPlansBySubscriptionId
{
    public class GetDietPlansBySubscriptionIdQueryHandler : IRequestHandler<GetDietPlansBySubscriptionIdQueryRequest, GetDietPlansBySubscriptionIdQueryResponse>
    {
        private readonly IDietPlanRepository _dietPlanRepository;
        private readonly IMapper _mapper;

        public GetDietPlansBySubscriptionIdQueryHandler(IDietPlanRepository dietPlanRepository, IMapper mapper)
        {
            _dietPlanRepository = dietPlanRepository;
            _mapper = mapper;
        }

        public async Task<GetDietPlansBySubscriptionIdQueryResponse> Handle(GetDietPlansBySubscriptionIdQueryRequest request, CancellationToken cancellationToken)
        {
            List<DietPlan> dietPlans = await _dietPlanRepository.GetWhere(dp => dp.SubscriptionId == request.SubscriptionId, tracking: false);
            if (!dietPlans.Any())
                return new(Messages.DietPlanNotFoundForSubscription, false, null);
            List<GetDietPlansBySubscriptionIdDto> getDietPlansBySubscriptionIdDtos = _mapper.Map<List<GetDietPlansBySubscriptionIdDto>>(dietPlans);
            return new(Messages.DietPlanListedSuccessful, true, getDietPlansBySubscriptionIdDtos);
        }
    }
}
