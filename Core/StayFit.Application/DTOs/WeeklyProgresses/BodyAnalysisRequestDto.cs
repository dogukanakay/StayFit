using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StayFit.Application.DTOs.WeeklyProgresses
{
    public record BodyAnalysisRequestDto
    {
        public string Height { get; init; }
        public List<BodyAnalysisImageDto> Images { get; init; }
    }
}
