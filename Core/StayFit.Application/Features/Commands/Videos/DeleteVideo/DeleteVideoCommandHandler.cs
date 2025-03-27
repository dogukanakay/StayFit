using MediatR;
using StayFit.Application.Constants.Messages;
using StayFit.Application.Repositories;
using StayFit.Domain.Entities;

namespace StayFit.Application.Features.Commands.Videos.DeleteVideo
{
    public class DeleteVideoCommandHandler : IRequestHandler<DeleteVideoCommandRequest, DeleteVideoCommandResponse>
    {
        private readonly IVideoRepository _videoRepository;

        public DeleteVideoCommandHandler(IVideoRepository videoRepository)
        {
            _videoRepository = videoRepository;
        }

        public async Task<DeleteVideoCommandResponse> Handle(DeleteVideoCommandRequest request, CancellationToken cancellationToken)
        {
            Video video =await _videoRepository.GetByIdAsync(request.VideoId);

            if (video == null)
                return new(Messages.VideoNotFound, false);

            await _videoRepository.Remove(video);

            var result = await _videoRepository.SaveAsync();

            return result >0 ? new(Messages.VideoDeletedSuccessfuly, true) : new(Messages.VideoDeleteFailed, false);
        }
    }
}
