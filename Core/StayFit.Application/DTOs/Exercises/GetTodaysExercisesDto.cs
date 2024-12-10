using StayFit.Application.DTOs.Abstracts;
using StayFit.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StayFit.Application.DTOs.Exercises
{
    public record GetTodaysExercisesDto : IDto
    {

        public int Id { get; init; }
        public int WorkoutDayId { get; init; }
        public bool IsCompleted { get; init; }
        public int Priority { get; init; }
        public string Name { get; init; }
        public string Description { get; init; }
        public int SetCount { get; init; }
        public int RepetitionCount { get; init; }
        public int DurationMinutes { get; init; }
        public ExerciseLevel ExerciseLevel { get; init; }
        public ExerciseCategory ExerciseCategory { get; init; }
    }
}
