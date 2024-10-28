using StayFit.Domain.Entities.Common;
using StayFit.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StayFit.Domain.Entities
{
    public class WorkoutPlan : BaseEntity<int>
    {
        public Guid SubscriptionId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public PlanStatus Status { get; set; }


        public Subscription Subscription { get; set; }
        public ICollection<WorkoutDay> WorkoutDays { get; set; }


    }
}
