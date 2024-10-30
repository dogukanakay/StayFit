using StayFit.Domain.Entities;
using StayFit.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StayFit.Application.DTOs
{
    public class CreateSubscriptionDto
    {
        public Guid MemberId { get; set; }
        public Guid TrainerId { get; set; }

      
    }
}
