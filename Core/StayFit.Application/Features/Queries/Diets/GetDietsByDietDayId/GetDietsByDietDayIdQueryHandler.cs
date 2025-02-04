using AutoMapper;
using MediatR;
using StayFit.Application.Constants.Messages;
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


        //[Cache("diets_{DietDayId}", 1000)]
        public async Task<GetDietsByDietDayIdQueryResponse> Handle(GetDietsByDietDayIdQueryRequest request, CancellationToken cancellationToken)
        {
            List<Diet> diets = await _dietRepository.GetWhere(d=>d.DietDayId == request.DietDayId, false);
            if (!diets.Any())
                return new( Messages.DietNotFoundForToday, false, null);
            List<GetDietsByDietDayIdDto> getDietsByDietDayIdDtos = _mapper.Map<List<GetDietsByDietDayIdDto>>(diets);
            return new(Messages.DietListedSuccessful, true, getDietsByDietDayIdDtos);
        }
    }
}
