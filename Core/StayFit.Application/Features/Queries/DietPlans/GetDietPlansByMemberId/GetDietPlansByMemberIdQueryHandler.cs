using AutoMapper;
using MediatR;
using StayFit.Application.Constants.Messages;
using StayFit.Application.DTOs.DietPlans;
using StayFit.Application.Repositories;
using StayFit.Domain.Entities;

namespace StayFit.Application.Features.Queries.DietPlans.GetDietPlansByMemberId
{
    public class GetDietPlansByMemberIdQueryHandler : IRequestHandler<GetDietPlansByMemberIdQueryRequest, GetDietPlansByMemberIdQueryResponse>
    {
        private readonly IDietPlanRepository _dietPlanRepository;
        private readonly IMapper _mapper;

        public GetDietPlansByMemberIdQueryHandler(IDietPlanRepository dietPlanRepository, IMapper mapper)
        {
            _dietPlanRepository = dietPlanRepository;
            _mapper = mapper;
        }

        public async Task<GetDietPlansByMemberIdQueryResponse> Handle(GetDietPlansByMemberIdQueryRequest request, CancellationToken cancellationToken)
        {
            List<DietPlan> dietPlans = await _dietPlanRepository.GetWhere(dp => dp.MemberId == request.MemberId, tracking: false);
            if (!dietPlans.Any())
                return new(Messages.DietPlanNotFoundForMember, false, null);
            List<GetDietPlansByMemberIdDto> getDietPlansByMemberIdDtos = _mapper.Map<List<GetDietPlansByMemberIdDto>>(dietPlans);
            return new(Messages.DietPlanListedSuccessful, true, getDietPlansByMemberIdDtos);
        }
    }
}
