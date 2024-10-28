﻿using StayFit.Domain.Entities.Common;
using StayFit.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StayFit.Domain.Entities
{
    public class Subscription : BaseEntity<Guid>
    {
        public Guid StudentId { get; set; }
        public Guid TrainerId { get; set; }
        public DateTime EndDate { get; set; }
        public float Amount { get; set; }
        public SubscriptionType SubscriptionType { get; set; }
        public PaymentStatus PaymentStatus { get; set; }

        public Member Student { get; set; }
        public Trainer Trainer { get; set; }
    }
}
