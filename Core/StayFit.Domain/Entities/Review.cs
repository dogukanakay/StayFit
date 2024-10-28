using StayFit.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StayFit.Domain.Entities
{
    public class Review : BaseEntity<int>
    {
        public Guid SubscriptionId { get; set; }
        public float Rate { get; set; }

        public Subscription Subscription { get; set; }
    }
}
