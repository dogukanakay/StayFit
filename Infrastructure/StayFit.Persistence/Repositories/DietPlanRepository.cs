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
        public DietPlanRepository(StayFitDbContext context) : base(context)
        {
        }
    }
}
