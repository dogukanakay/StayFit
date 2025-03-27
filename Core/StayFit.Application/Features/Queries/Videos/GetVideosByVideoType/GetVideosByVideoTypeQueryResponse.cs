using StayFit.Application.DTOs.Videos;

namespace StayFit.Application.Features.Queries.Videos.GetVideosByVideoType
{
    public class GetVideosByVideoTypeQueryResponse
    {
        public string Message { get; }
        public bool Success { get; }
        public List<GetVideosByVideoTypeDto>? GetVideosByVideoTypeDtos { get; }

        public GetVideosByVideoTypeQueryResponse(string message, bool success, List<GetVideosByVideoTypeDto>? getVideosByVideoTypeDtos = null)
        {
            Message = message;
            Success = success;
            GetVideosByVideoTypeDtos = getVideosByVideoTypeDtos;
        }
    }
}

