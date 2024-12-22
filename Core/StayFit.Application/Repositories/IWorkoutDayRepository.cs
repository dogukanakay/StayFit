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
        Task<bool> CheckIfWorkoutDayAlreadyExistAsync(int workoutPlanId, DayOfWeek day);
        Task<bool> CheckIfWorkoutDayAlreadyExistUpdateAsync(int id,int workoutPlanId, DayOfWeek day);

        
    }
}
