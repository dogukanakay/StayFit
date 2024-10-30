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
    public class TrainerRepository : GenericRepository<Trainer>, ITrainerRepository
    {
        private readonly StayFitDbContext _context;
        public TrainerRepository(StayFitDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Trainer> GetTrainerProfile(Guid id)
                => await _context.Trainers.Include(t => t.User).FirstOrDefaultAsync(t => t.Id == id);
    }
}
