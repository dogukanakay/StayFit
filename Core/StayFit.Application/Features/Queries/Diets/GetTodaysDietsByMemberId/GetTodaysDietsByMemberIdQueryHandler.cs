using AutoMapper;
using MediatR;
using StayFit.Application.Constants.Messages;
using StayFit.Application.DTOs.Diets;
using StayFit.Application.Repositories;
using StayFit.Domain.Entities;

namespace StayFit.Application.Features.Queries.Diets.GetTodaysDietsByMemberId
{
    public class GetTodaysDietsByMemberIdQueryHandler : IRequestHandler<GetTodaysDietsByMemberIdQueryRequest, GetTodaysDietsByMemberIdQueryResponse>
    {
        private readonly IDietRepository _dietRepository;
        private readonly IMapper _mapper;

        public GetTodaysDietsByMemberIdQueryHandler(IDietRepository dietRepository, IMapper mapper)
        {
            _dietRepository = dietRepository;
            _mapper = mapper;
        }

        public async Task<GetTodaysDietsByMemberIdQueryResponse> Handle(GetTodaysDietsByMemberIdQueryRequest request, CancellationToken cancellationToken)
        {
            List<Diet> diets = await _dietRepository.GetTodaysDietsAsync(request.MemberId);
            if (diets == null)
                return new(Messages.DietNotFoundForToday, false, null);
            List<GetTodaysDietsDto> getTodaysDietsDtos = _mapper.Map<List<GetTodaysDietsDto>>(diets);
            return new(Messages.DietListedSuccessful, true, getTodaysDietsDtos);
        }
    }
}
