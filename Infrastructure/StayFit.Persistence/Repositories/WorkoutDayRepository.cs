using Microsoft.EntityFrameworkCore;
using StayFit.Application.Repositories;
using StayFit.Domain.Entities;
using StayFit.Domain.Enums;
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
                => await _context.WorkoutDays.Where(wd => wd.DayOfWeek == day && wd.WorkoutPlanId == workoutPlanId).AnyAsync();


        public async Task<bool> CheckIfWorkoutDayAlreadyExistUpdateAsync(int id, int workoutPlanId, DayOfWeek day)
                => await _context.WorkoutDays.Where(wd => wd.DayOfWeek == day && wd.WorkoutPlanId == workoutPlanId && wd.Id != id).AnyAsync();

        public async Task<int> ResetCompletedWorkoutDaysAsync()
                => await _context.WorkoutDays.
                Where(wd => wd.WorkoutPlan.Status == PlanStatus.Active && wd.IsCompleted == true).
                ExecuteUpdateAsync(setter => setter.SetProperty(wd => wd.IsCompleted, false));
    }
}
