using StayFit.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StayFit.Application.Repositories
{
    public interface IExerciseRepository : IGenericRepository<Exercise>
    {
        Task<List<Exercise>> GetExercisesByWorkoutDayId(int workoutDayId);
        Task AddRangeAsync(List<Exercise> exerciseList);

        Task<List<Exercise>> GetTodaysExercisesAsync(Guid memberId);

        

    }
}
