using StayFit.Application.Abstracts.Services;
using StayFit.Application.Abstracts.Services.BackgroundServices;
using StayFit.Application.DTOs.WeeklyProgresses;
using StayFit.Application.Features.Commands.WeeklyProgresses.CreateWeeklyProgressByAI;
using StayFit.Application.Repositories;
using StayFit.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StayFit.Infrastructure.Concretes.Services.BackgroundServices
{
    public class BodyAnalysisBackgroundService : IBodyAnalysisBackgroundService
    {
        private readonly IBodyAnalysisAIService _bodyAnalysisAIService;
        private readonly IWeeklyProgressRepository _weeklyProgressRepository;

        public BodyAnalysisBackgroundService(IBodyAnalysisAIService bodyAnalysisAIService, IWeeklyProgressRepository weeklyProgressRepository)
        {
            _bodyAnalysisAIService = bodyAnalysisAIService;
            _weeklyProgressRepository = weeklyProgressRepository;
        }

        public async Task ProcessBodyAnalysis(int weeklyProgressId, BodyAnalysisRequestDto request)
        {
            try
            {
                var weeklyProgress = await _weeklyProgressRepository.GetByIdAsync(weeklyProgressId);

              
                var analysisResult = await _bodyAnalysisAIService.AnalyzeBodyMetrics(request);

                weeklyProgress.NeckCircumference = analysisResult.NeckCircumference;
                weeklyProgress.WaistCircumference = analysisResult.WaistCircumference;
                weeklyProgress.ChestCircumference = analysisResult.ChestCircumference;
                weeklyProgress.Fat = (float?)(86.010 * Math.Log10(analysisResult.WaistCircumference - analysisResult.NeckCircumference)
                    - 70.041 * Math.Log10(analysisResult.Height) + 36.76);
                weeklyProgress.BMI = weeklyProgress.Weight / (float)Math.Pow(weeklyProgress.Height / 100f, 2);
                weeklyProgress.ProgressStatus = ProgressStatus.Completed;

                await _weeklyProgressRepository.SaveAsync();

                // Kullanıcıya bildirim gönder
                //await _notificationService.SendNotification(weeklyProgress.UserId,
                //    "AI analizi tamamlandı",
                //    "Vücut analiz sonuçlarınız hazır. Gelişim sayfanızdan inceleyebilirsiniz.");
            }
            catch (Exception ex)
            {
                var weeklyProgress = await _weeklyProgressRepository.GetByIdAsync(weeklyProgressId);
                weeklyProgress.ProgressStatus = ProgressStatus.Failed;
                await _weeklyProgressRepository.SaveAsync();

                //// Hata bildirimi gönder
                //await _notificationService.SendNotification(weeklyProgress.UserId,
                //    "AI analizi başarısız",
                //    "Vücut analizi sırasında bir hata oluştu. Lütfen daha sonra tekrar deneyin.");
            }
        }
    }
}
