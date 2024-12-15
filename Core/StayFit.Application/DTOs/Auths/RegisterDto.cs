using StayFit.Application.DTOs.Abstracts;
using StayFit.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StayFit.Application.DTOs
{
    public record RegisterDto : IDto
    {
        public string FirstName { get; init; }
        public string LastName { get; init; }
        public string Email { get; init; }
        public string Phone { get; init; }
        public string Password { get; init; }
        public DateTime BirthDate { get; init; }
        public Gender Gender { get; init; }
    }
}
