using AutoMapper;
using MediatR;
using StayFit.Application.Constants.Messages;
using StayFit.Application.Repositories;
using StayFit.Domain.Entities;

namespace StayFit.Application.Features.Commands.Videos.CreateVideo
{
    public class CreateVideoCommandHandler : IRequestHandler<CreateVideoCommandRequest, CreateVideoCommandResponse>
    {
        private readonly IVideoRepository _videoRepository;
        private readonly IMapper _mapper;

        public CreateVideoCommandHandler(IVideoRepository videoRepository, IMapper mapper)
        {
            _videoRepository = videoRepository;
            _mapper = mapper;
        }

        public async Task<CreateVideoCommandResponse> Handle(CreateVideoCommandRequest request, CancellationToken cancellationToken)
        {
            Video video = _mapper.Map<Video>(request.CreateVideoDto);
            await _videoRepository.AddAsync(video);

            var result = await _videoRepository.SaveAsync();

            return result > 0  ? new(Messages.VideoCreatedSuccessfuly, true) : new(Messages.VideoCreateFailed, false);

        }
    }
}
