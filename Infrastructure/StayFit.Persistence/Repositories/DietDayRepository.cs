using Microsoft.EntityFrameworkCore;
using StayFit.Application.Repositories;
using StayFit.Domain.Entities;
using StayFit.Persistence.Contexts;

namespace StayFit.Persistence.Repositories
{
    public class DietDayRepository : GenericRepository<DietDay>, IDietDayRepository
    {
        private readonly StayFitDbContext _context;
        public DietDayRepository(StayFitDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<bool> CheckIfDietDayAlreadyExistAsync(int dietPlanId, DayOfWeek day)
            => await _context.DietDays.Where(dp => dp.DayOfWeek == day && dp.DietPlanId == dietPlanId).AnyAsync();

        public async Task<bool> CheckIfDietDayAlreadyExistUpdateAsync(int id, int dietPlanId, DayOfWeek day)
            =>await _context.DietDays.Where(dd => dd.DayOfWeek == day && dd.DietPlanId == dietPlanId && dd.Id != id).AnyAsync();
    }
}
