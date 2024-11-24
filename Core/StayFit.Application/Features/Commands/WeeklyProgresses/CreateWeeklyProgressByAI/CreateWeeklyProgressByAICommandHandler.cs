using AutoMapper;
using MediatR;
using StayFit.Application.Abstracts.Services;
using StayFit.Application.Abstracts.Storage;
using StayFit.Application.DTOs.WeeklyProgresses;
using StayFit.Application.Repositories;
using StayFit.Domain.Entities;

namespace StayFit.Application.Features.Commands.WeeklyProgresses.CreateWeeklyProgressByAI
{
    public class CreateWeeklyProgressByAICommandHandler : IRequestHandler<CreateWeeklyProgressByAICommandRequest, CreateWeeklyProgressByAICommandResponse>
    {
        private readonly IBodyAnalysisAIService _bodyAnalysisAIService;
        private readonly IWeeklyProgressRepository _weeklyProgressRepository;
        private readonly IProgressImageRepository _progressImageRepository;
        private readonly IMapper _mapper;
        private readonly IStorageService _storageService;


        public CreateWeeklyProgressByAICommandHandler(
            IBodyAnalysisAIService bodyAnalysisAIService,
            IWeeklyProgressRepository weeklyProgressRepository,
            IProgressImageRepository progressImageRepository,
            IMapper mapper,
            IStorageService storageService)
        {
            _bodyAnalysisAIService = bodyAnalysisAIService;
            _weeklyProgressRepository = weeklyProgressRepository;
            _progressImageRepository = progressImageRepository;
            _mapper = mapper;
            _storageService = storageService;
        }

        public async Task<CreateWeeklyProgressByAICommandResponse> Handle(CreateWeeklyProgressByAICommandRequest request, CancellationToken cancellationToken)
        {
            if (request.Images.Count == 2)
            {
                List<BodyAnalysisImageDto> bodyAnalysisImageDtos = new List<BodyAnalysisImageDto>();
                foreach (var image in request.Images)
                {
                    using var memoryStream = new MemoryStream();
                    await image.CopyToAsync(memoryStream);
                    string base64String = Convert.ToBase64String(memoryStream.ToArray());
                    BodyAnalysisImageDto bodyAnalysisImageDto = new()
                    {
                        Data = base64String,
                        FileName = image.FileName,
                    };
                    bodyAnalysisImageDtos.Add(bodyAnalysisImageDto);
                }
                BodyAnalysisRequestDto bodyAnalysisRequestDto = new()
                {
                    Height = request.CreateWeeklyProgressByAIDto.Height.ToString()+"cm",
                    Images = bodyAnalysisImageDtos
                };

                BodyAnalaysisResponseDto bodyAnalaysisResponseDto = await _bodyAnalysisAIService.AnalyzeBodyMetrics(bodyAnalysisRequestDto);

                WeeklyProgress weeklyProgress = new()
                {
                    BMI = 0,
                    Height = request.CreateWeeklyProgressByAIDto.Height,
                    NeckCircumference = bodyAnalaysisResponseDto.NeckCircumference,
                    WaistCircumference = bodyAnalaysisResponseDto.WaistCircumference,
                    SubscriptionId = Guid.Parse(request.CreateWeeklyProgressByAIDto.SubscriptionId),
                    Weight = request.CreateWeeklyProgressByAIDto.Weight,
                    ChestCircumference = bodyAnalaysisResponseDto.ChestCircumference,
                    CompletedWorkouts = 0,
                    Fat = (float?)(86.010 * Math.Log10(bodyAnalaysisResponseDto.WaistCircumference - bodyAnalaysisResponseDto.NeckCircumference) - 70.041 * Math.Log10(bodyAnalaysisResponseDto.Height) + 36.76),
                };

                var imageUploads = await _storageService.UploadAsync("progress-images", request.Images);
                foreach (var image in imageUploads)
                {
                    ProgressImage progressImage = new()
                    {
                        WeeklyProgress = weeklyProgress,
                        Path = $"{request.BaseStorageUrl}/{image.PathOrContainerName}",
                        FileName = image.fileName,

                    };
                    await _progressImageRepository.AddAsync(progressImage);
                }
                int result = await _progressImageRepository.SaveAsync();

                if (result > 0)
                    return new() { Message = "Fotoğraflarının AI tarafından inceleniyor, sonuçları birazdan gelişim sayfasınızda göreceksiniz.", Success = true };
                return new() { Message = "Haftalık gelişim eklenirken hata oluştu.", Success = false };

                
            }
            return new() { Message = "Hatalı fotoğraf gönderimi. 1 Tane önden, 1 tane yan taraftan çekilmiş 2 fotoğraf yollanmalı.", Success = false };
        }
    }
}
