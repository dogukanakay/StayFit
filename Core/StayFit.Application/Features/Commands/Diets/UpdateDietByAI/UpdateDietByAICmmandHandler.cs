using AutoMapper;
using Hangfire;
using MediatR;
using StayFit.Application.Abstracts.Services.BackgroundServices;
using StayFit.Application.DTOs.Diets;
using StayFit.Application.Repositories;
using StayFit.Domain.Entities;

namespace StayFit.Application.Features.Commands.Diets.UpdateDietByAI
{
    public class UpdateDietByAICmmandHandler : IRequestHandler<UpdateDietByAICommandRequest, UpdateDietByAICommandResponse>
    {
        private readonly IDietRepository _dietRepository;
        private readonly IBackgroundJobClient _backgroundJobClient;
        private readonly IMapper _mapper;

        public UpdateDietByAICmmandHandler(IDietRepository dietRepository, IBackgroundJobClient backgroundJobClient, IMapper mapper)
        {
            _dietRepository = dietRepository;
            _backgroundJobClient = backgroundJobClient;
            _mapper = mapper;
        }

        public async Task<UpdateDietByAICommandResponse> Handle(UpdateDietByAICommandRequest request, CancellationToken cancellationToken)
        {
            Diet diet = await _dietRepository.GetByIdAsync(request.DietId);
            if (diet == null)
                return new("Böyle bir diyet bulunamadı.", false);
            GetNewDietByAIRequestDto getNewDietByAIRequestDto = _mapper.Map<GetNewDietByAIRequestDto>(diet);

            _backgroundJobClient.Enqueue<IGetNewDietByAIBackgroundService>(service =>
                     service.GetNewDietByAIAsync(getNewDietByAIRequestDto, diet.Id, request.Prompt));

            return new("Yeni diyetiniz kısa süre içerisinde hazır olacak", true);

        }
    }
}
