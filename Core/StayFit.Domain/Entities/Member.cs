using StayFit.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StayFit.Domain.Entities
{
    public class Member : BaseEntity<Guid>
    {
        public int Height { get; set; }
        public float Weight { get; set; }
        public User User { get; set; }
    }
}
