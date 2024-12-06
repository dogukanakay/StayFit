using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StayFit.Application.Abstracts.Services.GenerativeAIServices
{
    public interface IGenerativeAIService
    {
        Task<string> GenerateContent(string promt);
    }
}
