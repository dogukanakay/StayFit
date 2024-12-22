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

        public async Task<bool> CheckIfMemberHasThisWorkoutDay(int id, Guid MemberId)
                => await _context.WorkoutDays.Where(wd=>wd.Id == id && wd.WorkoutPlan.MemberId == MemberId).AnyAsync();

        public async Task<bool> CheckIfWorkoutDayAlreadyExistAsync(int workoutPlanId, DayOfWeek day)
                => await _context.WorkoutDays.Where(wd => wd.DayOfWeek == day && wd.WorkoutPlanId == workoutPlanId).AnyAsync();


        public async Task<bool> CheckIfWorkoutDayAlreadyExistUpdateAsync(int id, int workoutPlanId, DayOfWeek day)
                => await _context.WorkoutDays.Where(wd => wd.DayOfWeek == day && wd.WorkoutPlanId == workoutPlanId && wd.Id != id).AnyAsync();


    }
}
