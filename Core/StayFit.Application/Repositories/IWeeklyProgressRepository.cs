﻿using StayFit.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StayFit.Application.Repositories
{
    public interface IWeeklyProgressRepository : IGenericRepository<WeeklyProgress>
    {
        public Task<List<WeeklyProgress>> GetWeeklyProgressBySubsIdDescAsync(Guid subscriptionId);
    }
}
