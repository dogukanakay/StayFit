using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StayFit.Application.DTOs.WorkoutPlans
{
    public record CreateWorkoutPlanDto
    {
        public string SubscriptionId { get; init; }
        public string MemberId { get; init; }
        public string Title { get; init; }
        public string Description { get; init; }
        public DateTime StartDate { get; init; }
        public DateTime EndDate { get; init; }
    }
}
