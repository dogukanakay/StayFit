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
    public class WorkoutDayRepository : GenericRepository<WorkoutDay>, IWorkoutDayRepository
    {
        private readonly StayFitDbContext _context;
        public WorkoutDayRepository(StayFitDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<bool> CheckIfWorkoutDayAlreadyExistAsync(int workoutPlanId, DayOfWeek day)
        {
            bool isAlreadyExit = await _context.WorkoutDays.Where(wd => wd.DayOfWeek == day && wd.WorkoutPlanId == workoutPlanId).AnyAsync();
            return isAlreadyExit;
        }
    }
}
