using StayFit.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StayFit.Domain.Entities
{
    public class Trainer : BaseEntity<Guid>
    {
        public string Bio { get; set; }
        public float MonthlyRate { get; set; }
        public float Rate { get; set; }
        public int YearsOfExperience { get; set; }
        public string Specializations { get; set; }
        public User User { get; set; }

    }
}
