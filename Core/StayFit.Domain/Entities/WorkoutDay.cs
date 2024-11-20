using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StayFit.Domain.Entities.Common;

namespace StayFit.Domain.Entities
{
    public class WorkoutDay : BaseEntity<int>
    {
        public int WorkoutPlanId { get; set; }
        public DateTime Day { get; set; }
        public bool IsCompleted { get; set; }

        public ICollection<Exercise> Exercises { get; set; }
        public WorkoutPlan WorkoutPlan { get; set; }

        [NotMapped]
        public override DateTime? DeletedDate { get => base.DeletedDate; set => base.DeletedDate = value; }

    }
}
