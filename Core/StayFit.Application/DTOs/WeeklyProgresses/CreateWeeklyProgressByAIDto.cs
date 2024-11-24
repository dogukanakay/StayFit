using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StayFit.Application.DTOs.WeeklyProgresses
{
    public record CreateWeeklyProgressByAIDto
    {
        public string SubscriptionId { get; init; }
        public int Height { get; init; }
        public int Weight { get; init; }
    }
}
