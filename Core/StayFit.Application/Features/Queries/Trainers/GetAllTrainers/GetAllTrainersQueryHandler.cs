using AutoMapper;
using MediatR;
using StayFit.Application.Constants.Messages;
using StayFit.Application.DTOs;
using StayFit.Application.Features.Queries.Trainers.GetTrainerProfile;
using StayFit.Application.Repositories;
using StayFit.Domain.Entities;

namespace StayFit.Application.Features.Queries.Trainers.GetAllTrainers
{
    public class GetAllTrainersQueryHandler : IRequestHandler<GetAllTrainersQueryRequest, GetAllTrainersQueryResponse>
    {
        private readonly ITrainerRepository _trainerRepository;
        private readonly IMapper _mapper;

        public GetAllTrainersQueryHandler(ITrainerRepository trainerRepository, IMapper mapper)
        {
            _trainerRepository = trainerRepository;
            _mapper = mapper;
        }

        public async Task<GetAllTrainersQueryResponse> Handle(GetAllTrainersQueryRequest request, CancellationToken cancellationToken)
        {
            List<Trainer> trainers = await _trainerRepository.GetAllTrainersIncludeUser();
            if (trainers is null)
                return new(Messages.TrainerNotFound, false, null);

            List<TrainerResponseDto> trainerResponseDtos = _mapper.Map<List<TrainerResponseDto>>(trainers);

            return new(Messages.TrainerListedSuccessful, true, trainerResponseDtos);
        }
    }

}
