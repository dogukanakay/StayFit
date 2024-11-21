using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StayFit.Application.DTOs.WorkoutDays
{
    public record GetWorkoutDaysByWorkoutPlanIdDto
    {
        public int Id { get; init; }
        public string Title { get; init; }
        public DayOfWeek DayOfWeek { get; init; }
        public bool IsCompleted { get; init; }
        public DateTime CreatedDate { get; init; }
        public string FormattedCreatedDate => CreatedDate.ToString("dd/MM/yyyy");
        public DateTime UpdatedDate { get; init; }
        public string FormattedUpdatedDate => UpdatedDate.ToString("dd/MM/yyyy");
    }
}
