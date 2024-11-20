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

        public async Task<WorkoutDay> CheckIfWorkoutDayAlreadyExist(int workoutPlanId, DateTime day)
        {
            WorkoutDay workoutDay = await _context.WorkoutDays.Where(wd => wd.Day.Date == day.Date && wd.WorkoutPlanId == workoutPlanId).FirstOrDefaultAsync();
            return workoutDay;
        }
    }
}
