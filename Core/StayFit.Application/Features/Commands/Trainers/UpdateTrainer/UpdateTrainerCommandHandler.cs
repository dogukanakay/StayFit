using AutoMapper;
using AutoMapper.Execution;
using MediatR;
using StayFit.Application.Commons.CustomAttributes.Caching;
using StayFit.Application.Constants.Messages;
using StayFit.Application.Repositories;
using StayFit.Domain.Entities;

namespace StayFit.Application.Features.Commands.Trainers.UpdateTrainer
{
    public class UpdateTrainerCommandHandler : IRequestHandler<UpdateTrainerCommandRequest, UpdateTrainerCommandResponse>
    {
        private readonly ITrainerRepository _trainerRepository;
        private readonly IMapper _mapper;

        public UpdateTrainerCommandHandler(ITrainerRepository trainerRepository, IMapper mapper)
        {
            _trainerRepository = trainerRepository;
            _mapper = mapper;
        }

        [CacheRemove("profiles_{TrainerId}")]
        public async Task<UpdateTrainerCommandResponse> Handle(UpdateTrainerCommandRequest request, CancellationToken cancellationToken)
        {
            Trainer trainer = await _trainerRepository.GetTrainerProfile(request.TrainerId);
            _mapper.Map(request.UpdateTrainerDto, trainer);


            _trainerRepository.Update(trainer);
            int result = await _trainerRepository.SaveAsync();

            return result > 0 ? new(Messages.TrainerProfileUpdatedSuccessful, true) : new(Messages.TrainerProfileUpdatedFailed, false);
        }
    }
}
