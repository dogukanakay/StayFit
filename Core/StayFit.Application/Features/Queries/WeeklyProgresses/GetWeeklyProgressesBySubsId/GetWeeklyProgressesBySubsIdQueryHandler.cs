using AutoMapper;
using MediatR;
using StayFit.Application.DTOs.WeeklyProgresses;
using StayFit.Application.Repositories;
using StayFit.Domain.Entities;

namespace StayFit.Application.Features.Queries.WeeklyProgresses.GetWeeklyProgressesBySubsId
{
    public class GetWeeklyProgressesBySubsIdQueryHandler : IRequestHandler<GetWeeklyProgressesBySubsIdQueryRequest, GetWeeklyProgressesBySubsIdQueryResponse>
    {
        private readonly IWeeklyProgressRepository _weeklyProgressRepository;
        private readonly IMapper _mapper;

        public GetWeeklyProgressesBySubsIdQueryHandler(IWeeklyProgressRepository weeklyProgressRepository, IMapper mapper)
        {
            _weeklyProgressRepository = weeklyProgressRepository;
            _mapper = mapper;
        }

        public async Task<GetWeeklyProgressesBySubsIdQueryResponse> Handle(GetWeeklyProgressesBySubsIdQueryRequest request, CancellationToken cancellationToken)
        {
            List<WeeklyProgress> weeklyProgresses = await _weeklyProgressRepository.GetWeeklyProgressBySubsIdDescAsync(request.SubscriptionId);
            if (weeklyProgresses == null)
                return new() { Message = "Bu abonelik için bir gelişim eklenmedi.", Success = false };
            List<GetWeeklyProgressesBySubsIdDto> getWeeklyProgressesBySubsIdDtos = _mapper.Map<List<GetWeeklyProgressesBySubsIdDto>>(weeklyProgresses);
            return new() { Message = "Bu abonelik eklenen gelişimler getirildi.", Success = true, GetWeeklyProgressesBySubsIdDtos = getWeeklyProgressesBySubsIdDtos };
        }
    }
}
