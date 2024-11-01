using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StayFit.Application.DTOs.Trainers
{
    public record UpdateTrainerDto
    {
        public string? Id { get; init; }
        public string? FirstName { get; init; }
        public string? LastName { get; init; }
        public string? Bio { get; init; }
        public float? MonthlyRate { get; init; }
        public int? YearsOfExperience { get; init; }
    }
}
