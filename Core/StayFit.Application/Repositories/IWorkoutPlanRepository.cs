using StayFit.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StayFit.Application.Repositories
{
    public interface IWorkoutPlanRepository : IGenericRepository<WorkoutPlan>
    {
        Task<bool> CheckIfAlreadyExistPlanOnTimeRange(Guid memberId, DateTime startDate, DateTime endDate);
    }
}
