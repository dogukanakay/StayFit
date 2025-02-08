using MediatR;
using StayFit.Application.Abstracts.Services.BackgroundServices;
using StayFit.Application.Abstracts.Services.Hangfire;
using StayFit.Application.Abstracts.Storage;
using StayFit.Application.Constants.Containers;
using StayFit.Application.Constants.Messages;
using StayFit.Application.DTOs.WeeklyProgresses;
using StayFit.Application.Features.Commands.WeeklyProgresses.CreateWeeklyProgressByAI;
using StayFit.Application.Repositories;
using StayFit.Domain.Entities;
using StayFit.Domain.Enums;

public class CreateWeeklyProgressByAICommandHandler : IRequestHandler<CreateWeeklyProgressByAICommandRequest, CreateWeeklyProgressByAICommandResponse>
{
    private readonly IJobSchedulerService _jobSchedulerService;
    private readonly IWeeklyProgressRepository _weeklyProgressRepository;
    private readonly IProgressImageRepository _progressImageRepository;
    private readonly IStorageService _storageService;

    public CreateWeeklyProgressByAICommandHandler(
        IJobSchedulerService jobSchedulerService,
        IWeeklyProgressRepository weeklyProgressRepository,
        IProgressImageRepository progressImageRepository,
        IStorageService storageService)
    {
        _jobSchedulerService = jobSchedulerService;
        _weeklyProgressRepository = weeklyProgressRepository;
        _progressImageRepository = progressImageRepository;
        _storageService = storageService;
    }

    public async Task<CreateWeeklyProgressByAICommandResponse> Handle(
        CreateWeeklyProgressByAICommandRequest request,
        CancellationToken cancellationToken)
    {
        if (request.Images.Count is not 2)
            return new(Messages.WeeklyProgressImageNotFound, false);

        var weeklyProgress = await CreateWeeklyProgressAsync(request);
        var progressImages = await SaveProgressImagesAsync(request, weeklyProgress);
        await EnqueueBodyAnalysisJob(request, weeklyProgress);

        return new(Messages.WeeklyProgressCreatedByAI, true);
    }

    private async Task<WeeklyProgress> CreateWeeklyProgressAsync(CreateWeeklyProgressByAICommandRequest request)
    {
        var weeklyProgress = new WeeklyProgress
        {
            Height = request.CreateWeeklyProgressByAIDto.Height,
            Weight = request.CreateWeeklyProgressByAIDto.Weight,
            SubscriptionId = Guid.Parse(request.CreateWeeklyProgressByAIDto.SubscriptionId),
            ProgressStatus = ProgressStatus.Progress,
            Creator = WeeklyProgressCreator.AI
        };

        await _weeklyProgressRepository.AddAsync(weeklyProgress);
        await _weeklyProgressRepository.SaveAsync();

        return weeklyProgress;
    }

    private async Task<List<ProgressImage>> SaveProgressImagesAsync(
        CreateWeeklyProgressByAICommandRequest request,
        WeeklyProgress weeklyProgress)
    {
        var imageUploads = await _storageService.UploadAsync(Containers.ProgressImageContainer, request.Images);

        var progressImages = imageUploads.Select(image => new ProgressImage
        {
            WeeklyProgress = weeklyProgress,
            Path = image.PathOrContainerName,
            FileName = image.fileName
        }).ToList();

        await _progressImageRepository.AddRangeAsync(progressImages);
        await _progressImageRepository.SaveAsync();

        return progressImages;
    }

    private async Task EnqueueBodyAnalysisJob(
        CreateWeeklyProgressByAICommandRequest request,
        WeeklyProgress weeklyProgress)
    {
        var bodyAnalysisImageDtos = await Task.WhenAll(request.Images.Select(async image =>
        {
            using var memoryStream = new MemoryStream();
            await image.CopyToAsync(memoryStream);
            return new BodyAnalysisImageDto
            {
                Data = Convert.ToBase64String(memoryStream.ToArray()),
                FileName = image.FileName,
            };
        }));

        var bodyAnalysisRequestDto = new BodyAnalysisRequestDto
        {
            Height = $"{request.CreateWeeklyProgressByAIDto.Height}cm",
            Images = bodyAnalysisImageDtos.ToList()
        };

        _jobSchedulerService.Enqueue<IBodyAnalysisBackgroundService>(
            service => service.ProcessBodyAnalysis(weeklyProgress.Id, bodyAnalysisRequestDto));
    }
}