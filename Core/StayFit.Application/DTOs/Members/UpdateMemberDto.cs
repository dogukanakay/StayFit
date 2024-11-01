using StayFit.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StayFit.Application.DTOs.Members
{
    public record UpdateMemberDto
    {
        public string? Id { get; init; }
        public string? FirstName { get; init; }
        public string? LastName { get; init; }
        public int? Height { get; init; }
        public float? Weight { get; init; }
    }
}
