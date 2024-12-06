using StayFit.Application.DTOs.Diets;
using StayFit.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StayFit.Application.Abstracts.Services.BackgroundServices
{
    public interface IGetNewDietByAIBackgroundService
    {
        Task GetNewDietByAIAsync(GetNewDietByAIRequestDto getNewDietByAIRequestDto, int dietId);
    }
}
