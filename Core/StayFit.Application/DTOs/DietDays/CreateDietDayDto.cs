using StayFit.Application.DTOs.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StayFit.Application.DTOs.DietDays
{
    public record CreateDietDayDto : IDto
    {
        public int DietPlanId { get; init; }
        public DayOfWeek DayOfWeek { get; init; }
        public string Title { get; init; }
    }
}
