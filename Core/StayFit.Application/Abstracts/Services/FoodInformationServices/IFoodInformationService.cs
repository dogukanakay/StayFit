using StayFit.Application.DTOs.FoodInformations.Fatsecrets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StayFit.Application.Abstracts.Services.FoodInformationServices
{
    public interface IFoodInformationService
    {
        Task<List<Food>> SearchFoodsByNameAsync(string foodName, int pageNumber = 1, int maxResults =10, bool includeFoodImages = false);

    }
}
