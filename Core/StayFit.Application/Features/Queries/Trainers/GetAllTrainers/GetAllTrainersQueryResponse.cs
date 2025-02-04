using StayFit.Application.DTOs;

namespace StayFit.Application.Features.Queries.Trainers.GetAllTrainers
{
    public class GetAllTrainersQueryResponse
    {
        public string Message { get; }
        public bool Success { get; }
        public List<TrainerResponseDto>? TrainerResponseDtos { get;}

        public GetAllTrainersQueryResponse(string message, bool success, List<TrainerResponseDto>? trainerResponseDtos)
        {
            Message = message;
            Success = success;
            TrainerResponseDtos = trainerResponseDtos;
        }
    }

}
