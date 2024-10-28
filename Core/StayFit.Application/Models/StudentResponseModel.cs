using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StayFit.Application.Models
{
    public class StudentResponseModel
    {
        public String Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string? PhotoPath { get; set; }
        public int Height { get; set; }
        public float Weight { get; set; }
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; }
    }
}
