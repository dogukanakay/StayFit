using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StayFit.Application.Abstracts.Services.TranslationServices
{
    public interface ITranslationService
    {
        Task<string> TranslateTextAsync(string text, string targetLanguage, string sourceLanguage = "");
        Task<List<string>> TranslateTextListAsync(List<string> textList, string targetLanguage, string sourceLanguage = "");
    }
}
