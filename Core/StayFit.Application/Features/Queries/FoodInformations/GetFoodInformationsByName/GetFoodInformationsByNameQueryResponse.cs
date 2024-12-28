using StayFit.Application.DTOs.FoodInformations.Fatsecrets;

namespace StayFit.Application.Features.Queries.FoodInformations.GetFoodInformationsByName
{
    public class GetFoodInformationsByNameQueryResponse
    {
        public string Message { get; }
        public bool Success { get;}
        public List<Food>? Foods { get; }

        public GetFoodInformationsByNameQueryResponse(string message, bool success, List<Food>? foods)
        {
            Message = message;
            Success = success;
            Foods = foods;
        }
    }
}
