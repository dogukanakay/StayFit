using MediatR;
using StayFit.Application.Abstracts.Storage;
using StayFit.Application.Repositories;
using StayFit.Domain.Entities;

namespace StayFit.Application.Features.Commands.Users.UpdateUserPhoto
{
    public class UpdateUserPhotoCommandHandler : IRequestHandler<UpdateUserPhotoCommandRequest, UpdateUserPhotoCommandResponse>
    {
        private readonly IStorageService _storageService;
        private readonly IUserRepository _userRepository;

        public UpdateUserPhotoCommandHandler(IStorageService storageService, IUserRepository userRepository)
        {
            _storageService = storageService;
            _userRepository = userRepository;
        }

        public async Task<UpdateUserPhotoCommandResponse> Handle(UpdateUserPhotoCommandRequest request, CancellationToken cancellationToken)
        {
            var result = await _storageService.UploadAsync("user-images", request.Files);
            var user = await _userRepository.GetByIdAsync(request.UserId);
            user.PhotoPath = $"{request.BaseStorageUrl}/{result[0].PathOrContainerName}";

            int response = await _userRepository.SaveAsync();

            return response > 0 ? new("Fotoğraf başarıyla güncellendi", true) : new("Fotoğraf güncellenirken bir hata oluştu", false);
        }
    }
}
