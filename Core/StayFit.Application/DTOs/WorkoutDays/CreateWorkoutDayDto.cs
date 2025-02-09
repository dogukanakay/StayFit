﻿using StayFit.Application.DTOs.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StayFit.Application.DTOs.WorkoutDays
{
    public record CreateWorkoutDayDto : IDto
    {
        public int WorkoutPlanId { get; init; }
        public DayOfWeek DayOfWeek { get; init; }
        public string Title { get; init; }
    }
}
