using StayFit.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StayFit.Application.DTOs
{
    public record GetTrainerSubscribersDto
    {
        public Guid Id { get; init; }
        public Guid MemberId { get; init; }
        public DateTime EndDate { get; init; }
        public float Amount { get; init; }
        public int Height { get; init; }
        public float Weight { get; init; }
        public string FirstName { get; init; }
        public string LastName { get; init; }
        public Gender Gender { get; init; }
        public DateTime BirthDate { get; init; }

    }
}
