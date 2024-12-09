using AutoMapper;
using MediatR;
using StayFit.Application.CustomAttributes.Caching;
using StayFit.Application.DTOs.Diets;
using StayFit.Application.Repositories;
using StayFit.Domain.Entities;

namespace StayFit.Application.Features.Queries.Diets.GetDietsByDietDayId
{
    public class GetDietsByDietDayIdQueryHandler : IRequestHandler<GetDietsByDietDayIdQueryRequest, GetDietsByDietDayIdQueryResponse>
    {
        private readonly IDietRepository _dietRepository;
        private readonly IMapper _mapper;

        public GetDietsByDietDayIdQueryHandler(IDietRepository dietRepository, IMapper mapper)
        {
            _dietRepository = dietRepository;
            _mapper = mapper;
        }


        [Cache("diets_{DietDayId}", 1000)]
        public async Task<GetDietsByDietDayIdQueryResponse> Handle(GetDietsByDietDayIdQueryRequest request, CancellationToken cancellationToken)
        {
            List<Diet> diets = await _dietRepository.GetWhere(d=>d.DietDayId == request.DietDayId, false);
            if (!diets.Any())
                return new(null, "Bu güne ait diyet listesi bulunamadı", false);
            List<GetDietsByDietDayIdDto> getDietsByDietDayIdDtos = _mapper.Map<List<GetDietsByDietDayIdDto>>(diets);
            return new(getDietsByDietDayIdDtos, "İlgili güne ait diyet listesi getirildi", true);
        }
    }
}
