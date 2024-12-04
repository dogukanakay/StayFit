using Microsoft.EntityFrameworkCore;
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
    }
}
