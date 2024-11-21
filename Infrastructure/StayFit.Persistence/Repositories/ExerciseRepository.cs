using Microsoft.EntityFrameworkCore;
using StayFit.Application.Repositories;
using StayFit.Domain.Entities;
using StayFit.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StayFit.Persistence.Repositories
{
    public class ExerciseRepository : GenericRepository<Exercise>, IExerciseRepository
    {
        private readonly StayFitDbContext _context;
        public ExerciseRepository(StayFitDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task AddRangeAsync(List<Exercise> exerciseList)
        {
            await _context.Exercises.AddRangeAsync(exerciseList);
        }

        public async Task<List<Exercise>> GetExercisesByWorkoutDayId(int workoutDayId)
            => await _context.Exercises.Where(e=>e.WorkoutDayId == workoutDayId).AsNoTracking().ToListAsync();
    }
}

