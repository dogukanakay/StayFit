using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StayFit.Application.Abstracts.Services.FoodInformationServices.FatsecretService;
using StayFit.Application.Abstracts.Services.TranslationServices;

namespace StayFit.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestsController : ControllerBase
    {
        private readonly IFatsecretService _fatsecretService;
        private readonly ITranslationService _translationService;

        public TestsController(IFatsecretService fatsecretService, ITranslationService translationService)
        {
            _fatsecretService = fatsecretService;
            _translationService = translationService;
        }

        [HttpGet]
        public async Task<IActionResult> GetFoods(string foodName)
        {
            var response = await _translationService.TranslateTextAsync(foodName, "en", "tr");
            var foods = await _fatsecretService.SearchFoodsByNameAsync(response, 1, 10, "tr", "TR", true);

            foreach (var food in foods)
            {
                food.FoodName = await _translationService.TranslateTextAsync(food.FoodName, "tr", "en");
                foreach (var serving in food.Servings.Serving)
                {
                    serving.ServingDescription = await _translationService.TranslateTextAsync(serving.ServingDescription, "tr", "en");
                }
            }
            return Ok(foods);
        }

        [HttpGet("Translate")]
        public async Task<IActionResult> Translate(string name)
        {
            var response = await _translationService.TranslateTextAsync(name, "en", "tr");
            return Ok(response);
        }
    }
}
