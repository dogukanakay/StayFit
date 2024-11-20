﻿using StayFit.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StayFit.Application.DTOs.Exercises
{
    public record GetExercisesByWorkoutPlanIdDto
    {
        public int ExerciseId { get; set; }
        public int WorkoutDayId { get; init; }
        public DateTime Day { get; init; }
        public bool IsCompleted { get; init; }
        public string Name { get; init; }
        public string Description { get; init; }
        public int SetCount { get; init; }
        public int RepetitionCount { get; init; }
        public int DurationMinutes { get; init; }
        public ExerciseLevel ExerciseLevel { get; init; }
        public ExerciseCategory ExerciseCategory { get; init; }
    }
}
