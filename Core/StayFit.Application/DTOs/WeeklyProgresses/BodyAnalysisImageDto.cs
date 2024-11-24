using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StayFit.Application.DTOs.WeeklyProgresses
{
    public record BodyAnalysisImageDto
    {
        public string Data { get; set; }
        public string FileName { get; set; }
    }
}
