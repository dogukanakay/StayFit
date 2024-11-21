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
        public Task<List<Exercise>> GetExercisesByWorkoutDayId(int workoutDayId);
        public Task AddRangeAsync(List<Exercise> exerciseList);
    }
}
