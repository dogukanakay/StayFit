using Microsoft.Extensions.Configuration;
using StayFit.Application.Abstracts.Services.GenerativeAIServices;
using StayFit.Application.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace StayFit.Infrastructure.Concretes.Services.AIServices.GenerativeAIServices
{
    public class GeminiService : IGeminiService
    {
        private readonly GeminiSettings _settings;
        private readonly HttpClient _httpClient;
        public GeminiService( HttpClient httpClient, IConfiguration configuration)
        {
            _settings = configuration.GetSection("AIServices:Gemini").Get<GeminiSettings>();
            _httpClient = httpClient;
        }

        public async Task<string> GenerateContent(string prompt)
        {
            // Prompt'u escape et
            prompt = JsonSerializer.Serialize(prompt);

            var requestBody = new
            {
                contents = new[]
                {
                new
                {
                    parts = new[]
                    {
                        new { text = prompt }
                    }
                }
            }
            };

            var jsonData = JsonSerializer.Serialize(requestBody);
            string requestUrl = $"{_settings.Endpoint}?key={_settings.ApiKey}";

            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(requestUrl, content);

            if (!response.IsSuccessStatusCode)
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                throw new Exception($"API Error: {response.StatusCode} - {errorContent}");
            }

            var responseBody = await response.Content.ReadAsStringAsync();
            return responseBody;


        }
    }
}
