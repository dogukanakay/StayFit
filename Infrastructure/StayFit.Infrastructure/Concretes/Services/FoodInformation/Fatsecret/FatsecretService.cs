using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using StayFit.Application.Abstracts.Services.FoodInformationServices.FatsecretService;
using StayFit.Application.DTOs.FoodInformations.Fatsecrets;
using System.Net.Http.Headers;

public class FatsecretService : IFatsecretService
{
    private readonly HttpClient _httpClient;
    private readonly IFatsecretTokenService _tokenService;
    private readonly string _baseUrl = "https://platform.fatsecret.com/rest/";

    public FatsecretService(HttpClient httpClient, IFatsecretTokenService tokenService)
    {
        _httpClient = httpClient;
        _tokenService = tokenService;
    }

    public async Task<List<Food>> SearchFoodsByNameAsync(string foodName, int pageNumber, int maxResults, bool includeFoodImages)
    {
        var token = await _tokenService.GetAccessTokenAsync();
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

        var queryParams = new Dictionary<string, string>
        {
            { "search_expression", foodName },
            { "format", "json" },
            { "page_number", pageNumber.ToString() },
            { "max_results", maxResults.ToString() }
        };


        if (includeFoodImages)
            queryParams.Add("include_food_images", "true");

        string url = QueryHelpers.AddQueryString($"{_baseUrl}foods/search/v3", queryParams);

        var response = await _httpClient.GetAsync(url);

        if (!response.IsSuccessStatusCode)
        {
            var errorContent = await response.Content.ReadAsStringAsync();
            throw new Exception($"FatSecret API Error: {errorContent}");
        }

        var content = await response.Content.ReadAsStringAsync();

        var foodSearchResult = JsonConvert.DeserializeObject<FoodSearchResult>(content);
        if (foodSearchResult?.FoodsSearch?.Results == null)
            return new List<Food>();

        return foodSearchResult.FoodsSearch.Results.Food;
    }
}

