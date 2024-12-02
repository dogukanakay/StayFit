using StayFit.Application.DTOs.WeeklyProgresses;
using StayFit.Application.Features.Commands.WeeklyProgresses.CreateWeeklyProgressByAI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StayFit.Application.Abstracts.Services.BackgroundServices
{
    public interface IBodyAnalysisBackgroundService
    {
        Task ProcessBodyAnalysis(int weeklyProgressId, BodyAnalysisRequestDto request);
    }
}
