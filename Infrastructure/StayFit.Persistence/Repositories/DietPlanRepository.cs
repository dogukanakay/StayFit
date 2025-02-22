﻿using Microsoft.EntityFrameworkCore;
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
    public class DietPlanRepository : GenericRepository<DietPlan>, IDietPlanRepository
    {
        private readonly StayFitDbContext _context;
        public DietPlanRepository(StayFitDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<bool> CheckIfAlreadyExistPlanOnTimeRange(Guid memberId, DateTime startDate, DateTime endDate)
                 => await _context.WorkoutPlans
             .Where(wp => wp.MemberId == memberId &&
             (startDate >= wp.StartDate && startDate <= wp.EndDate) ||
             endDate >= wp.StartDate && endDate <= wp.EndDate).AnyAsync();
    }
}
