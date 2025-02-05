using MediatR;
using StayFit.Application.Abstracts.Services.FoodInformationServices;
using StayFit.Application.Abstracts.Services.TranslationServices;
using StayFit.Application.Commons.Exceptions.Business;
using StayFit.Application.Constants.Messages;
using StayFit.Application.DTOs.FoodInformations.Fatsecrets;

namespace StayFit.Application.Features.Queries.FoodInformations.GetFoodInformationsByName
{
    public class GetFoodInformationsByNameQueryHandler : IRequestHandler<GetFoodInformationsByNameQueryRequest, GetFoodInformationsByNameQueryResponse>
    {
        private readonly IFoodInformationService _foodInformationService;
        private readonly ITranslationService _translationService;

        public GetFoodInformationsByNameQueryHandler(
            IFoodInformationService foodInformationService,
            ITranslationService translationService)
        {
            _foodInformationService = foodInformationService;
            _translationService = translationService;
        }

        public async Task<GetFoodInformationsByNameQueryResponse> Handle(
            GetFoodInformationsByNameQueryRequest request,
            CancellationToken cancellationToken)
        {
            throw new BusinessException("Buradayımmmm");

            string translatedFoodName = await _translationService.TranslateTextAsync(request.FoodName, "en", "tr");

            List<Food> foods = await _foodInformationService.SearchFoodsByNameAsync(translatedFoodName, includeFoodImages: true);

            if (!foods.Any())
                return new(Messages.FoodInformationsNotFound, false, null);


            var foodNames = foods.Select(f => f.FoodName).ToList();
            var servingDescriptions = foods.SelectMany(f => f.Servings.Serving.Select(s => s.ServingDescription)).ToList();

            var translationTasks = new[]
            {
                _translationService.TranslateTextListAsync(foodNames, "tr", "en"),
                _translationService.TranslateTextListAsync(servingDescriptions, "tr", "en")
            };

            await Task.WhenAll(translationTasks);

            var translatedFoodNames = translationTasks[0].Result;
            var translatedServingDescriptions = translationTasks[1].Result;

            ApplyTranslationsToFoods(foods, translatedFoodNames, translatedServingDescriptions);

            return new GetFoodInformationsByNameQueryResponse(Messages.FoodInformationsListedSuccessful, true, foods);
        }

        private void ApplyTranslationsToFoods(
            List<Food> foods,
            List<string> translatedFoodNames,
            List<string> translatedServingDescriptions)
        {
            for (int i = 0; i < foods.Count; i++)
            {
                foods[i].FoodName = translatedFoodNames[i];
            }

            int descriptionIndex = 0;
            foreach (var food in foods)
            {
                foreach (var serving in food.Servings.Serving)
                {
                    serving.ServingDescription = translatedServingDescriptions[descriptionIndex];
                    descriptionIndex++;
                }
            }
        }
    }
}
