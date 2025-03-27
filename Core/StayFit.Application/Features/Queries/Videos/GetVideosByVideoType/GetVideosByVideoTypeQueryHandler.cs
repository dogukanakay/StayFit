using AutoMapper;
using MediatR;
using StayFit.Application.Constants.Messages;
using StayFit.Application.DTOs.Videos;
using StayFit.Application.Repositories;
using StayFit.Domain.Entities;

namespace StayFit.Application.Features.Queries.Videos.GetVideosByVideoType
{
    public class GetVideosByVideoTypeQueryHandler : IRequestHandler<GetVideosByVideoTypeQueryRequest, GetVideosByVideoTypeQueryResponse>
    {
        private readonly IVideoRepository _videoRepository;
        private readonly IMapper _mapper;

        public GetVideosByVideoTypeQueryHandler(IVideoRepository videoRepository, IMapper mapper)
        {
            _videoRepository = videoRepository;
            _mapper = mapper;
        }

        public async Task<GetVideosByVideoTypeQueryResponse> Handle(GetVideosByVideoTypeQueryRequest request, CancellationToken cancellationToken)
        {
            List<Video> Videos = await _videoRepository.GetVideosByVideoType(request.VideoType);

            List<GetVideosByVideoTypeDto> getVideosByVideoTypeDtos = _mapper.Map<List<GetVideosByVideoTypeDto>>(Videos);

            return Videos.Any() ? new(Messages.VideosListedSuccessfuly, true, getVideosByVideoTypeDtos) : new(Messages.VideoNotFound, false);



        }
    }
}
