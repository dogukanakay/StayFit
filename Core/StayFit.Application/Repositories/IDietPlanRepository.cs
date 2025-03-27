using StayFit.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StayFit.Application.Repositories
{
    public interface IDietPlanRepository : IGenericRepository<DietPlan>
    {
        Task<bool> CheckIfAlreadyExistPlanOnTimeRangeAsync(Guid memberId, DateTime startDate, DateTime endDate);
        Task<Guid?> GetTrainerIdByDietPlanIdAsync(int dietPlanId);

    }
}
