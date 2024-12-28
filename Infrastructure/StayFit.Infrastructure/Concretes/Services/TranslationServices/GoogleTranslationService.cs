using Google.Apis.Translate.v2.Data;
using Google.Cloud.Translation.V2;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using StayFit.Application.Abstracts.Services.TranslationServices;
using static System.Net.Mime.MediaTypeNames;

namespace StayFit.Infrastructure.Concretes.Services.TranslationServices
{
    public class GoogleTranslationService : IGoogleTranslationService
    {
        private readonly TranslationClient _translationClient;
        private readonly ILogger<GoogleTranslationService> _logger;

        public GoogleTranslationService(IConfiguration configuration, ILogger<GoogleTranslationService> logger)
        {
            var apiKey = configuration["GoogleTranslate:ApiKey"];
            _translationClient = TranslationClient.CreateFromApiKey(apiKey);
            _logger = logger;
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
                _logger.LogError($"Translation failed: {ex.Message}", ex);
                throw new Exception($"Translation failed: {ex.Message}", ex);
            }
        }

        public async Task<List<string>> TranslateTextListAsync(List<string> textList, string targetLanguage, string sourceLanguage = "")
        {
            var response = await _translationClient.TranslateTextAsync(textList, targetLanguage, sourceLanguage);
            return response.Select(t => t.TranslatedText).ToList();
        }
    }
}
