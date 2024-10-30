using AutoMapper;
using MediatR;
using StayFit.Application.DTOs;
using StayFit.Application.Repositories;
using StayFit.Domain.Entities;

namespace StayFit.Application.Features.Queries.Trainers.GetTrainerProfile
{
    public class GetTrainerProfileQueryHandler : IRequestHandler<GetTrainerProfileQueryRequest, GetTrainerProfileQueryResponse>
    {
        private readonly ITrainerRepository _trainerRepository;
        private readonly IMapper _mapper;

        public GetTrainerProfileQueryHandler(ITrainerRepository trainerRepository, IMapper mapper)
        {
            _trainerRepository = trainerRepository;
            _mapper = mapper;
        }

        public async Task<GetTrainerProfileQueryResponse> Handle(GetTrainerProfileQueryRequest request, CancellationToken cancellationToken)
        {
            Trainer trainer = await _trainerRepository.GetTrainerProfile(request.TrainerId);
            TrainerResponseDto trainerResponseDto = _mapper.Map<TrainerResponseDto>(trainer);
            return new()
            {
                TrainerResponseDto = trainerResponseDto,
            };
        }
    }
}
