using StayFit.Application.DTOs.WeeklyProgresses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StayFit.Application.Abstracts.Services
{
    public interface IBodyAnalysisAIService
    {
        public Task<BodyAnalaysisResponseDto> AnalyzeBodyMetrics(BodyAnalysisRequestDto bodyAnalysisRequestDto);
    }
}
