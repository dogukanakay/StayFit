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
        Task<bool> CheckIfDietDayAlreadyExistAsync(int dietPlanId, DayOfWeek day);
        Task<bool> CheckIfDietDayAlreadyExistUpdateAsync(int id, int dietPlanId, DayOfWeek day);
        Task<int> ResetCompletedDietDaysAsync();

    }
}
