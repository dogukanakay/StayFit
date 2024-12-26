using Microsoft.Extensions.Configuration;
using StayFit.Application.Abstracts.Services.TranslationServices;
using Google.Cloud.Translation.V2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StayFit.Infrastructure.Concretes.Services.TranslationServices
{
    public class GoogleTranslationService : IGoogleTranslationService
    {
        private readonly TranslationClient _translationClient;

        public GoogleTranslationService(IConfiguration configuration)
        {
            var apiKey = configuration["GoogleTranslate:ApiKey"];
            _translationClient = TranslationClient.CreateFromApiKey(apiKey);
        }
        public async Task<string> TranslateTextAsync(string text, string targetLanguage, string sourceLanguage = "")
        {
            try
            {
                var response = await _translationClient.TranslateTextAsync(
                    text: text,
                    targetLanguage: targetLanguage,
                    sourceLanguage: sourceLanguage);

                return response.TranslatedText;
            }
            catch (Exception ex)
            {
                // Log the exception
                throw new Exception($"Translation failed: {ex.Message}", ex);
            }
        }
    }
}
