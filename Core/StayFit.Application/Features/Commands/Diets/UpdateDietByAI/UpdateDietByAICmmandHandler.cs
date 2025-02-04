using AutoMapper;
using MediatR;
using StayFit.Application.Abstracts.Services.BackgroundServices;
using StayFit.Application.Abstracts.Services.Hangfire;
using StayFit.Application.Constants.Messages;
using StayFit.Application.DTOs.Diets;
using StayFit.Application.Repositories;
using StayFit.Domain.Entities;

namespace StayFit.Application.Features.Commands.Diets.UpdateDietByAI
{
    public class UpdateDietByAICmmandHandler : IRequestHandler<UpdateDietByAICommandRequest, UpdateDietByAICommandResponse>
    {
        private readonly IDietRepository _dietRepository;
        private readonly IJobSchedulerService _jobSchedulerService;
        private readonly IMapper _mapper;

        public UpdateDietByAICmmandHandler(IDietRepository dietRepository, IJobSchedulerService jobSchedulerService, IMapper mapper)
        {
            _dietRepository = dietRepository;
            _jobSchedulerService = jobSchedulerService;
            _mapper = mapper;
        }

        public async Task<UpdateDietByAICommandResponse> Handle(UpdateDietByAICommandRequest request, CancellationToken cancellationToken)
        {
            Diet diet = await _dietRepository.GetByIdAsync(request.DietId);
            if (diet == null)
                return new(Messages.DietNotFound, false);
            GetNewDietByAIRequestDto getNewDietByAIRequestDto = _mapper.Map<GetNewDietByAIRequestDto>(diet);

            _jobSchedulerService.Enqueue<IGetNewDietByAIBackgroundService>(service =>
                     service.GetNewDietByAIAsync(getNewDietByAIRequestDto, diet.Id, request.Prompt));

            return new(Messages.DietUpdatedByAI, true);

        }
    }
}
