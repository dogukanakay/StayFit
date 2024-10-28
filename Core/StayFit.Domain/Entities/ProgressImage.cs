using StayFit.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StayFit.Domain.Entities
{
    public class ProgressImage : BaseEntity<int>
    {

        public int WeeklyProgressId { get; set; }
        public string Path { get; set; }
        public string FileName { get; set; }

        public WeeklyProgress WeeklyProgress { get; set; }


        [NotMapped]
        public override DateTime? UpdatedDate { get => base.UpdatedDate; set => base.UpdatedDate = value; }
        [NotMapped]
        public override DateTime? DeletedDate { get => base.DeletedDate; set => base.DeletedDate = value; }
    }
}
