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
    public class Goal : BaseEntity<int>
    {
        public Guid MemberId { get; set; }
        public GoalType GoalType { get; set; }
        public string Description { get; set; }
        public float TargetValue { get; set; }
        public float StartValue { get; set; }
        public float CurrentValue { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime TargetDate { get; set; }
        public GoalStatus Status { get; set; }


        public Member Member { get; set; }



        [NotMapped]
        public override DateTime? DeletedDate { get => base.DeletedDate; set => base.DeletedDate = value; }
    }
}
