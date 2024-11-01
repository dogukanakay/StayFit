using AutoMapper;
using AutoMapper.Execution;
using MediatR;
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

        public async Task<UpdateTrainerCommandResponse> Handle(UpdateTrainerCommandRequest request, CancellationToken cancellationToken)
        {
            Trainer trainer = await _trainerRepository.GetTrainerProfile(Guid.Parse(request.UpdateTrainerDto.Id));
            _mapper.Map(request.UpdateTrainerDto, trainer);
            

            var result = _trainerRepository.Update(trainer);

            if (result)
            {
                await _trainerRepository.SaveAsync();
                return new() { Message = "Profil bilgileri başarıyla güncellendi.", Success = true };
            }


            return new() { Message = "HATA. Profil bilgileri güncellenemedi.", Success = false };
        }
    }
}
