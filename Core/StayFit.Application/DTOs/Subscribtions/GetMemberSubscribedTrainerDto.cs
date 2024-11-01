using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StayFit.Application.DTOs
{
    public record GetMemberSubscribedTrainerDto
    {
        public Guid SubscriptionId { get; init; }
        public Guid TrainerId { get; init; }
        public string FirstName { get; init; }
        public string LastName { get; init; }
        public float Amount { get; init; }
        public DateTime EndDate { get; init; }
        public string? PhotoPath { get; init; }

    }
}
