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

        public async Task GetNewDietByAIAsync(GetNewDietByAIRequestDto getNewDietByAIRequestDto, int dietId, string prompt)
        {
            var mealJson = JsonSerializer.Serialize(getNewDietByAIRequestDto, new JsonSerializerOptions
            {
                WriteIndented = true
            });

            

            var promptTemplate = @"Bu modele gore yeni bir diyet onerisi yap:
{0}

{1}
";

            var formattedPrompt = string.Format(promptTemplate, mealJson, prompt);

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
