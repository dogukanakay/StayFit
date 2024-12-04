using StayFit.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StayFit.Application.Repositories
{
    public interface IDietDayRepository : IGenericRepository<DietDay>
    {
        public Task<bool> CheckIfDietDayAlreadyExistAsync(int dietPlanId, DayOfWeek day);
    }
}
