using AutoMapper;
using MediatR;
using StayFit.Application.Commons.CustomAttributes.Caching;
using StayFit.Application.Constants.Messages;
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

        [Cache("profiles_{TrainerId}", 1000)]
        public async Task<GetTrainerProfileQueryResponse> Handle(GetTrainerProfileQueryRequest request, CancellationToken cancellationToken)
        {
            Trainer trainer = await _trainerRepository.GetTrainerProfile(request.TrainerId);

            if (trainer is null)
                return new(Messages.TrainerProfileNotFound, false, null);
                         
            
            TrainerResponseDto trainerResponseDto = _mapper.Map<TrainerResponseDto>(trainer);

            return new(Messages.TrainerProfileLoadedSuccessful, true, trainerResponseDto);
        }
    }
}
