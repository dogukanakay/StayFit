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
    public class WorkoutPlanRepository : GenericRepository<WorkoutPlan>, IWorkoutPlanRepository
    {
        private readonly StayFitDbContext _context;
        public WorkoutPlanRepository(StayFitDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<bool> CheckIfAlreadyExistPlanOnTimeRange(DateTime startDate, DateTime endDate)
                => await _context.WorkoutPlans
            .Where(wp => 
            (wp.StartDate >= startDate && wp.StartDate <= endDate) ||
            wp.EndDate>=startDate && wp.EndDate<=endDate).AnyAsync();
    }
}
