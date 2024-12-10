using Microsoft.EntityFrameworkCore;
using StayFit.Application.Repositories;
using StayFit.Domain.Entities;
using StayFit.Persistence.Contexts;

namespace StayFit.Persistence.Repositories
{
    public class DietRepository : GenericRepository<Diet>, IDietRepository
    {
        private readonly StayFitDbContext _context;
        public DietRepository(StayFitDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task AddRangeAsync(List<Diet> dietList)
        {
            await _context.Diets.AddRangeAsync(dietList);
        }

        public async Task<List<Diet>> GetTodaysDietsAsync(Guid memberId)
        {
            return await _context.Diets
                .Where(
                d => d.DietDay.DietPlan.MemberId == memberId &&
                d.DietDay.DayOfWeek == DateTime.Today.DayOfWeek &&
                d.DietDay.DietPlan.StartDate <= DateTime.UtcNow &&
                d.DietDay.DietPlan.EndDate >= DateTime.UtcNow)
                    .OrderBy(d=>d.MealType)
                    .AsNoTracking()
                    .ToListAsync();
        }
    }
}
