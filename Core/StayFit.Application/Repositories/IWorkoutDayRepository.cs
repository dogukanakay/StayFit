using StayFit.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StayFit.Application.Repositories
{
    public interface IWorkoutDayRepository : IGenericRepository<WorkoutDay>
    {
        public Task<bool> CheckIfWorkoutDayAlreadyExistAsync(int workoutPlanId, DayOfWeek day);
    }
}
