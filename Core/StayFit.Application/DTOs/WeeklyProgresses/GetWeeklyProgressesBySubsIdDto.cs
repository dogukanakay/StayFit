using StayFit.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StayFit.Application.DTOs.WeeklyProgresses
{
    public record GetWeeklyProgressesBySubsIdDto
    {
        public int Id { get; init; }
        public int Height { get; init; }
        public float Weight { get; init; }
        public float Fat { get; init; }
        public float BMI { get; init; }
        public float WaistCircumference { get; init; }
        public float NeckCircumference { get; init; }
        public float ChestCircumference { get; init; }
        public DateTime CreatedDate { get; set; }
        public string FormattedCreatedDate => CreatedDate.ToString("dd/MM/yyyy");
        public WeeklyProgressCreator Creator { get; set; }
    }
}
