using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StayFit.Domain.Entities.Common
{
    public abstract class BaseEntity
    {
        public DateTime CreatedDate { get; set; }
        public virtual DateTime? UpdatedDate { get; set; }
        public virtual DateTime? DeletedDate { get; set; }
    }

    public class BaseEntity<T> : BaseEntity
    {
        public T Id { get; set; }
    }
}
