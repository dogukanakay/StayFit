using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StayFit.Domain.Entities.Common
{
    public class BaseEntity<T>
    {
        public T Id { get; set; }
        public DateTime CreatedDate { get; set; }
        virtual public DateTime? UpdatedDate { get; set; }
        virtual public DateTime? DeletedDate { get; set; }
    }
}
