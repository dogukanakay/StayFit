﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StayFit.Application.Models
{
    public class TrainerResponseModel
    {
        public String Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string? PhotoPath { get; set; }
        public string Bio { get; set; }
        public float MonthlyRate { get; set; }
        public float Rate { get; set; }
        public int YearsOfExperience { get; set; }
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; }

    }
}
