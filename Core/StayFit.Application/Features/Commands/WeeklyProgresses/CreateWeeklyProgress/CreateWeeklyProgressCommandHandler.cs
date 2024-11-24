using AutoMapper;
using MediatR;
using StayFit.Application.Abstracts.Storage;
using StayFit.Application.Repositories;
using StayFit.Domain.Entities;

namespace StayFit.Application.Features.Commands.WeeklyProgresses.CreateWeeklyProgress
{
    public class CreateWeeklyProgressCommandHandler : IRequestHandler<CreateWeeklyProgressCommandRequest, CreateWeeklyProgressCommandResponse>
    {
        private readonly IProgressImageRepository _progressImageRepository;
        private readonly IWeeklyProgressRepository _weeklyProgressRepository;
        private readonly IStorageService _storageService;
        private readonly IMapper _mapper;

        public CreateWeeklyProgressCommandHandler(IProgressImageRepository progressImageRepository,
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
            WeeklyProgress weeklyProgress = _mapper.Map<WeeklyProgress>(request.CreateWeeklyProgressDto);
            int result = 0;
            if (request.Images.Count>0)
            {
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
                result = await _progressImageRepository.SaveAsync();

                if (result > 0)
                    return new() { Message = "Haftalık gelişim başarıyla eklendi.", Success = true };
                return new() { Message = "Haftalık gelişim eklenirken hata oluştu.", Success = false };
            }
            await _weeklyProgressRepository.AddAsync(weeklyProgress);
            result = await _weeklyProgressRepository.SaveAsync();
            if (result > 0)
                return new() { Message = "Haftalık gelişim başarıyla eklendi.", Success = true };
            return new() { Message = "Haftalık gelişim eklenirken hata oluştu.", Success = false };

        }
    }
}
