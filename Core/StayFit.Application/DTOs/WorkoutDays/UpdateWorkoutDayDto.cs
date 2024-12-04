using StayFit.Application.DTOs.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StayFit.Application.DTOs.WorkoutDays
{
    public record UpdateWorkoutDayDto : IDto
    {
        public int Id { get; init; }
        public DayOfWeek DayOfWeek { get; init; }
        public string Title { get; init; }
        public bool IsCompleted { get; init; }
    }
}
