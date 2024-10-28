using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StayFit.Application.Models
{
    public class StudentRegisterModel : RegisterModel
    {
        public int Height { get; set; }
        public float Weight { get; set; }
    }
}
