using StayFit.Application.Abstracts.Services.BackgroundServices;
using StayFit.Application.Abstracts.Services.GenerativeAIServices;
using StayFit.Application.DTOs.Diets;
using StayFit.Application.DTOs.Gemini;
using StayFit.Application.Repositories;
using StayFit.Domain.Entities;
using StayFit.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace StayFit.Infrastructure.Concretes.Services.BackgroundServices
{
    public class GetNewDietByAIBackgroundService : IGetNewDietByAIBackgroundService
    {
        private readonly IGeminiService _geminiService;
        private readonly IDietRepository _dietRepository;

        public GetNewDietByAIBackgroundService(IGeminiService geminiService, IDietRepository dietRepository)
        {
            _geminiService = geminiService;
            _dietRepository = dietRepository;
        }

        public async Task GetNewDietByAIAsync(GetNewDietByAIRequestDto getNewDietByAIRequestDto, int dietId)
        {
            var mealJson = JsonSerializer.Serialize(getNewDietByAIRequestDto, new JsonSerializerOptions
            {
                WriteIndented = true
            });

            var promptTemplate = @"Bu modele gore yeni bir oneri yap:
{0}

Yukaridaki degerlere sadik kalarak veya cok benzer degerler ile yeni bir yemek oner. 
Portion ve Unit degisebilir onemli olan calories, carbs, protein ve fat yeni onerecegin yemekte de ayni veya benzer miktarda olmali. 
Bunu onerirken hangi ogunun olduguna ve turk yemeklerinden olmasina dikkat et.
Biraz yaratici ol ve sporcuya yonelik yemekler oner.
Bana donus degeri olarak sana verdigim yapinin aynisini tek don baska bir sey yazma. 
Sadece JSON formatinda don.";

            var formattedPrompt = string.Format(promptTemplate, mealJson);

            try
            {
                var geminiResponse = await _geminiService.GenerateContent(formattedPrompt);

                var options = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                    AllowTrailingCommas = true,
                    IgnoreNullValues = true
                };

                var response = JsonSerializer.Deserialize<GeminiResponse>(geminiResponse, options);

                var responseText = response?.Candidates?.FirstOrDefault()?.Content?.Parts?.FirstOrDefault()?.Text;



                if (string.IsNullOrEmpty(responseText))
                {
                    throw new Exception("API boş yanıt döndü");
                }
                try
                {
                    var jsonMatch = System.Text.RegularExpressions.Regex.Match(responseText, @"\{[^{}]*\}");
                    if (jsonMatch.Success)
                    {
                        var extractedJson = jsonMatch.Value;
                        var newDiet = JsonSerializer.Deserialize<GetNewDietByAIResponseDto>(extractedJson);
                        Diet diet = await _dietRepository.GetByIdAsync(dietId);
                        diet.Portion = newDiet.Portion;
                        diet.Fat = newDiet.Fat;
                        diet.FoodName = newDiet.FoodName;
                        diet.Carbs = newDiet.Carbs;
                        diet.Creator = DietCreator.AI;
                        diet.Calories = newDiet.Calories;
                        diet.Protein = newDiet.Protein;
                        diet.Unit = newDiet.Unit;
                        await _dietRepository.SaveAsync();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Yanıtta geçerli JSON bulunamadı :" +ex.Message);
                }


                
            }
            catch (Exception ex)
            {
                throw new Exception($"API işleminde hata: {ex.Message}");
            }
        }
    }
}
