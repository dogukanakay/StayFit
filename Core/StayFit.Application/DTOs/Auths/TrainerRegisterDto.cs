using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StayFit.Application.DTOs
{
    public record TrainerRegisterDto:RegisterDto
    {
        public string Bio { get; init; }
        public float MonthlyRate { get; init; }
        public int YearsOfExperience { get; init; }
        public string? Specializations { get; init; }

    }
}
