using AutoMapper;
using MediatR;
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
            List<DietDay> dietDays = await _dietDayRepository.GetWhere(dd=>dd.DietPlanId == request.DietPlanId, tracking : false);
            if (!dietDays.Any())
                return new("Bu plana ait bir gün bulunamadı", false, null);
            List<GetDietDaysByDietPlanIdDto> getDietDaysByDietPlanIdDtos = _mapper.Map<List<GetDietDaysByDietPlanIdDto>>(dietDays);

            return new("Diyet günleri başarıyla listelendi.", true, getDietDaysByDietPlanIdDtos);

        }
    }
}
