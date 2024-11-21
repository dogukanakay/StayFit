using StayFit.Domain.Entities.Common;
using StayFit.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StayFit.Domain.Entities
{
    public class Exercise : BaseEntity<int>
    {
        public int WorkoutDayId { get; set; }
        public string Name { get; set; }
        public int Priority { get; set; }
        public string Description { get; set; }
        public int SetCount { get; set; }
        public int RepetitionCount { get; set; }
        public int DurationMinutes { get; set; }
        public ExerciseLevel ExerciseLevel { get; set; }
        public ExerciseCategory ExerciseCategory { get; set; }

        public WorkoutDay WorkoutDay { get; set; }

    }
}
