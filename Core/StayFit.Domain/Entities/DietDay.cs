using StayFit.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StayFit.Domain.Entities
{
    public class DietDay : BaseEntity<int>
    {
        public int DietPlanId { get; set; }
        public DayOfWeek DayOfWeek { get; set; }
        public string Notes { get; set; }
        public bool IsCompleted { get; set; }

        public ICollection<Diet> Diets { get; set; }
        public DietPlan DietPlan { get; set; }

        [NotMapped]
        public override DateTime? DeletedDate { get => base.DeletedDate; set => base.DeletedDate = value; }
    }
}
