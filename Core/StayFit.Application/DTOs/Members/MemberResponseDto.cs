using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StayFit.Application.DTOs
{
    public record MemberResponseDto
    {
        public string Id { get; init; }
        public DateTime CreatedDate { get; init; }
        public string FormattedCreatedDate => CreatedDate.ToString("dd/MM/yyyy");
        public string FirstName { get;  init; }
        public string LastName { get; init; }
        public string Email { get; init; }
        public string Phone { get; init; }
        public string? PhotoPath { get; init; }
        public int Height { get; init; }
        public float Weight { get; init; }
        public DateTime BirthDate { get; init; }
        public string FormattedBirthDate => BirthDate.ToString("dd/MM/yyyy");
        public string Gender { get; init; }
    }
}
