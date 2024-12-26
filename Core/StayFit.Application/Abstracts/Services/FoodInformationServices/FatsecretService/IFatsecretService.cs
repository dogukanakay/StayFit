using StayFit.Application.DTOs.FoodInformations.Fatsecrets;

namespace StayFit.Application.Abstracts.Services.FoodInformationServices.FatsecretService
{
    public interface IFatsecretService
    {
        Task<List<Food>> SearchFoodsByNameAsync(string foodName, int pageNumber, int maxResults, string region = null, string language = null, bool includeFoodImages = false);
    }
}
