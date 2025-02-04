using AutoMapper;
using MediatR;
using StayFit.Application.Abstracts.Storage;
using StayFit.Application.Constants.Messages;
using StayFit.Application.DTOs.WeeklyProgresses;
using StayFit.Application.Repositories;
using StayFit.Domain.Entities;
using StayFit.Domain.Enums;

namespace StayFit.Application.Features.Commands.WeeklyProgresses.CreateWeeklyProgress
{
    public class CreateWeeklyProgressCommandHandler : IRequestHandler<CreateWeeklyProgressCommandRequest, CreateWeeklyProgressCommandResponse>
    {
        private readonly IProgressImageRepository _progressImageRepository;
        private readonly IWeeklyProgressRepository _weeklyProgressRepository;
        private readonly IStorageService _storageService;
        private readonly IMapper _mapper;

        public CreateWeeklyProgressCommandHandler(
            IProgressImageRepository progressImageRepository,
            IWeeklyProgressRepository weeklyProgressRepository,
            IStorageService storageService,
            IMapper mapper)
        {
            _progressImageRepository = progressImageRepository;
            _weeklyProgressRepository = weeklyProgressRepository;
            _storageService = storageService;
            _mapper = mapper;
        }

        public async Task<CreateWeeklyProgressCommandResponse> Handle(CreateWeeklyProgressCommandRequest request, CancellationToken cancellationToken)
        {
            var weeklyProgress = _mapper.Map<WeeklyProgress>(request.CreateWeeklyProgressDto);
            weeklyProgress.ProgressStatus = ProgressStatus.Completed;
            weeklyProgress.Creator = WeeklyProgressCreator.Member;
            weeklyProgress.Fat = CalculateFatPercentage(weeklyProgress.WaistCircumference, weeklyProgress.NeckCircumference, weeklyProgress.Height);
            weeklyProgress.BMI = CalculateBMI(weeklyProgress.Weight, weeklyProgress.Height);

            if (request.Images.Any())
            {
                await UploadAndSaveImagesAsync(request, weeklyProgress);
            }
            else
            {
                await _weeklyProgressRepository.AddAsync(weeklyProgress);
            }

            int result = await _weeklyProgressRepository.SaveAsync();
            
            return result > 0 ? new(Messages.WeeklyProgressCreatedSuccessful, true) : new(Messages.WeeklyProgressCreatedFailed, false);
        }

        private static float CalculateFatPercentage(float waist, float neck, float height) =>
            (float)(86.010 * Math.Log10(waist - neck) - 70.041 * Math.Log10(height) + 36.76);

        private static float CalculateBMI(float weight, float height) =>
            weight / (float)Math.Pow(height / 100f, 2);

        private async Task UploadAndSaveImagesAsync(CreateWeeklyProgressCommandRequest request, WeeklyProgress weeklyProgress)
        {
            var imageUploads = await _storageService.UploadAsync("progress-images", request.Images);
            var progressImages = imageUploads.Select(image => new ProgressImage
            {
                WeeklyProgress = weeklyProgress,
                Path = $"{request.BaseStorageUrl}/{image.PathOrContainerName}",
                FileName = image.fileName
            }).ToList();

            await _progressImageRepository.AddRangeAsync(progressImages);
        }
    }
}
