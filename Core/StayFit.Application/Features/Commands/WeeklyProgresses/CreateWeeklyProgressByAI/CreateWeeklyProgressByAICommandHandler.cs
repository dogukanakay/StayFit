using AutoMapper;
using Hangfire;
using MediatR;
using StayFit.Application.Abstracts.Services;
using StayFit.Application.Abstracts.Services.BackgroundServices;
using StayFit.Application.Abstracts.Storage;
using StayFit.Application.DTOs.WeeklyProgresses;
using StayFit.Application.Features.Commands.WeeklyProgresses.CreateWeeklyProgressByAI;
using StayFit.Application.Repositories;
using StayFit.Domain.Entities;
using StayFit.Domain.Enums;

public class CreateWeeklyProgressByAICommandHandler : IRequestHandler<CreateWeeklyProgressByAICommandRequest, CreateWeeklyProgressByAICommandResponse>
{
    private readonly IBackgroundJobClient _backgroundJobClient;
    private readonly IWeeklyProgressRepository _weeklyProgressRepository;
    private readonly IProgressImageRepository _progressImageRepository;
    private readonly IMapper _mapper;
    private readonly IStorageService _storageService;

    public CreateWeeklyProgressByAICommandHandler(
        IBackgroundJobClient backgroundJobClient,
        IWeeklyProgressRepository weeklyProgressRepository,
        IProgressImageRepository progressImageRepository,
        IMapper mapper,
        IStorageService storageService)
    {
        _backgroundJobClient = backgroundJobClient;
        _weeklyProgressRepository = weeklyProgressRepository;
        _progressImageRepository = progressImageRepository;
        _mapper = mapper;
        _storageService = storageService;
    }

    public async Task<CreateWeeklyProgressByAICommandResponse> Handle(CreateWeeklyProgressByAICommandRequest request, CancellationToken cancellationToken)
    {
        if (request.Images.Count != 2)
            return new() { Message = "Hatalı fotoğraf gönderimi. 1 Tane önden, 1 tane yan taraftan çekilmiş 2 fotoğraf yollanmalı.", Success = false };

        var imageUploads = await _storageService.UploadAsync("progress-images", request.Images);
        var weeklyProgress = new WeeklyProgress
        {
            Height = request.CreateWeeklyProgressByAIDto.Height,
            Weight = request.CreateWeeklyProgressByAIDto.Weight,
            SubscriptionId = Guid.Parse(request.CreateWeeklyProgressByAIDto.SubscriptionId),
            ProgressStatus = ProgressStatus.Progress 
        };

        foreach (var image in imageUploads)
        {
            var progressImage = new ProgressImage
            {
                WeeklyProgress = weeklyProgress,
                Path = $"{request.BaseStorageUrl}/{image.PathOrContainerName}",
                FileName = image.fileName,
            };
            await _progressImageRepository.AddAsync(progressImage);
        }

        await _progressImageRepository.SaveAsync();

        List<BodyAnalysisImageDto> bodyAnalysisImageDtos = new();
        foreach (var image in request.Images)
        {
            using var memoryStream = new MemoryStream();
            await image.CopyToAsync(memoryStream);
            string base64String = Convert.ToBase64String(memoryStream.ToArray());
            bodyAnalysisImageDtos.Add(new BodyAnalysisImageDto
            {
                Data = base64String,
                FileName = image.FileName,
            });
        }

        var bodyAnalysisRequestDto = new BodyAnalysisRequestDto
        {
            Height = $"{request.CreateWeeklyProgressByAIDto.Height}cm",
            Images = bodyAnalysisImageDtos
        };

        _backgroundJobClient.Enqueue<IBodyAnalysisBackgroundService>(
            service => service.ProcessBodyAnalysis(weeklyProgress.Id, bodyAnalysisRequestDto));

        return new()
        {
            Message = "Fotoğraflarınız başarıyla yüklendi. AI analizi arka planda devam ediyor, sonuçlar hazır olduğunda bildirim alacaksınız.",
            Success = true
        };
    }
}