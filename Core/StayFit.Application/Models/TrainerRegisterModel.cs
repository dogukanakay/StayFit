using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StayFit.Application.Models
{
    public class TrainerRegisterModel:RegisterModel
    {
        public string Bio { get; set; }
        public float MonthlyRate { get; set; }
        public int YearsOfExperience { get; set; }
    }
}
