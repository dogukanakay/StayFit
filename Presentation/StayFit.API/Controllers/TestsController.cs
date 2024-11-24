using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StayFit.Application.Abstracts.Services;
using StayFit.Application.DTOs.WeeklyProgresses;

namespace StayFit.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestsController : ControllerBase
    {
        private readonly IBodyAnalysisAIService _bodyAnalysisAIService;

        public TestsController(IBodyAnalysisAIService bodyAnalysisAIService)
        {
            _bodyAnalysisAIService = bodyAnalysisAIService;
        }

        [HttpPost]
        public async Task<IActionResult> BodyEstimate(BodyAnalysisRequestDto bodyAnalysisRequestDto)
        {
            var response = await _bodyAnalysisAIService.AnalyzeBodyMetrics(bodyAnalysisRequestDto);
            return Ok(response);
        }
    }
}
