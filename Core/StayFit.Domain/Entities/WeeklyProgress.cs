using StayFit.Domain.Entities.Common;
using StayFit.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StayFit.Domain.Entities
{
    public class WeeklyProgress : BaseEntity<int>
    {

        public Guid SubscriptionId { get; set; }
        public int Height { get; set; }
        public float Weight { get; set; }
        public float Fat { get; set; }
        public float BMI { get; set; }
        public float WaistCircumference { get; set; }
        public float NeckCircumference { get; set; }
        public float ChestCircumference { get; set; }
        public int? CompletedWorkouts { get; set; }
        public ProgressStatus ProgressStatus { get; set; }
        public WeeklyProgressCreator Creator { get; set; }
        public Subscription Subscription { get; set; }

        [NotMapped]
        public override DateTime? DeletedDate { get => base.DeletedDate; set => base.DeletedDate = value; }

    }
}
