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
    public class WeeklyProgressRepository : GenericRepository<WeeklyProgress>, IWeeklyProgressRepository
    {
        private readonly StayFitDbContext _context;
        public WeeklyProgressRepository(StayFitDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<WeeklyProgress>> GetWeeklyProgressBySubsIdDescAsync(Guid subscriptionId)
           => await _context.WeeklyProgresses.Where(wp => wp.SubscriptionId == subscriptionId && wp.ProgressStatus == ProgressStatus.Completed).OrderByDescending(wp => wp.Id).AsNoTracking().ToListAsync();

    }
}
