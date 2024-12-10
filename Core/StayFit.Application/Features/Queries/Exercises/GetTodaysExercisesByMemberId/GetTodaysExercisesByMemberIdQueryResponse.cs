using StayFit.Application.DTOs.Diets;
using StayFit.Application.DTOs.Exercises;

namespace StayFit.Application.Features.Queries.Exercises.GetTodaysExercisesByMemberId
{
    public class GetTodaysExercisesByMemberIdQueryResponse
    {
        public string Messsage { get;}
        public bool Success { get; }
        public List<GetTodaysExercisesDto>? GetTodaysExercisesDtos { get;}

        public GetTodaysExercisesByMemberIdQueryResponse(string messsage, bool success)
        {
            Messsage = messsage;
            Success = success;
        }

        public GetTodaysExercisesByMemberIdQueryResponse(string messsage, bool success, List<GetTodaysExercisesDto>? getTodaysExercisesDtos)
        {
            Messsage = messsage;
            Success = success;
            GetTodaysExercisesDtos = getTodaysExercisesDtos;
        }
    }
}
