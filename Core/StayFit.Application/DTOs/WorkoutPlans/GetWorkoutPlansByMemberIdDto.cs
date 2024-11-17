using StayFit.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StayFit.Application.DTOs.WorkoutPlans
{
    public record GetWorkoutPlansByMemberIdDto
    {
        public int Id { get; init; }
        public string Title { get; init; }
        public string Description { get; init; }
        public DateTime StartDate { get; init; }
        public string FormattedStartDate => StartDate.ToString("dd/MM/yyyy");
        public DateTime EndDate { get; init; }
        public string FormattedEndDate => EndDate.ToString("dd/MM/yyyy");
        public PlanStatus Status { get; init; }
    }
}
