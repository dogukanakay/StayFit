using StayFit.Application.DTOs;

namespace StayFit.Application.Features.Queries.Trainers.GetTrainerProfile
{
    public class GetTrainerProfileQueryResponse
    {
        public string Message { get; }
        public bool Success { get; }
        public TrainerResponseDto? TrainerResponseDto { get; }

        public GetTrainerProfileQueryResponse(string message, bool success, TrainerResponseDto? trainerResponseDto)
        {
            Message = message;
            Success = success;
            TrainerResponseDto = trainerResponseDto;
        }
    }
}
