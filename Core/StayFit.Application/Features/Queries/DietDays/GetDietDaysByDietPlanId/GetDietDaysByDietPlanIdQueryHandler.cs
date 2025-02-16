using AutoMapper;
using MediatR;
using StayFit.Application.Constants.Messages;
using StayFit.Application.DTOs.DietDays;
using StayFit.Application.Repositories;
using StayFit.Domain.Entities;

namespace StayFit.Application.Features.Queries.DietDays.GetDietDaysByDietPlanId
{
    public class GetDietDaysByDietPlanIdQueryHandler : IRequestHandler<GetDietDaysByDietPlanIdQueryRequest, GetDietDaysByDietPlanIdQueryResponse>
    {
        private readonly IDietDayRepository _dietDayRepository;
        private readonly IMapper _mapper;

        public GetDietDaysByDietPlanIdQueryHandler(IDietDayRepository dietDayRepository, IMapper mapper)
        {
            _dietDayRepository = dietDayRepository;
            _mapper = mapper;
        }

        public async Task<GetDietDaysByDietPlanIdQueryResponse> Handle(GetDietDaysByDietPlanIdQueryRequest request, CancellationToken cancellationToken)
        {
            List<DietDay> dietDays = await _dietDayRepository
                .GetWhere(dd=>(dd.DietPlanId == request.DietPlanId) 
                && (dd.DietPlan.MemberId == request.UserId || dd.DietPlan.TrainerId == request.UserId), tracking : false);
            if (!dietDays.Any())
                return new(Messages.DietDayNotFound, false, null);
            List<GetDietDaysByDietPlanIdDto> getDietDaysByDietPlanIdDtos = _mapper.Map<List<GetDietDaysByDietPlanIdDto>>(dietDays);

            return new(Messages.DietDayListedSuccessful, true, getDietDaysByDietPlanIdDtos);

        }
    }
}
