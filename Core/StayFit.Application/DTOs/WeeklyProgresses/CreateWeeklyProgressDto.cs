using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StayFit.Application.DTOs.WeeklyProgresses
{
    public record CreateWeeklyProgressDto
    {
        public string SubscriptionId { get; init; }
        public int Height { get; init; }
        public float Weight { get; init; }
        public float Fat { get; init; }
        public float BMI { get; init; }
        public float WaistCircumference { get; init; }
        public float NeckCircumference { get; init; }
        public float ChestCircumference { get; init; }
    }
}
