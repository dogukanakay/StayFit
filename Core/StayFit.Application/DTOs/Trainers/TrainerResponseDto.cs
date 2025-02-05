using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StayFit.Application.DTOs
{
    public record TrainerResponseDto
    {
        public string Id { get; init; }
        public DateTime CreatedDate { get; init; }
        public string FormattedCreatedDate => CreatedDate.ToString("dd/MM/yyyy");
        public string FirstName { get; init; }
        public string LastName { get; init; }
        public string Email { get; init; }
        public string Phone { get; init; }
        public string? PhotoPath { get; init; }
        public string Bio { get; init; }
        public float MonthlyRate { get; init; }
        public float Rate { get; init; }
        public int YearsOfExperience { get; init; }
        public DateTime BirthDate { get; init; }
        public string FormattedBirthDate => BirthDate.ToString("dd/MM/yyyy");
        public string Gender { get; init; }

    }
}
