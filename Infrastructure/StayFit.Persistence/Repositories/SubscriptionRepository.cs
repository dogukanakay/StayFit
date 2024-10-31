using Microsoft.EntityFrameworkCore;
using StayFit.Application.DTOs;
using StayFit.Application.Repositories;
using StayFit.Domain.Entities;
using StayFit.Domain.Enums;
using StayFit.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StayFit.Persistence.Repositories
{
    public class SubscriptionRepository : GenericRepository<Subscription>, ISubscriptionRepository
    {
        private readonly StayFitDbContext _context;
        public SubscriptionRepository(StayFitDbContext context) : base(context)
        {
            _context = context;
        }

        //public async Task<List<Subscription>> GetTrainerSubscribers(Guid trainerId)
        //{
        //    List<Subscription> result = await _context.Subscriptions
        //                            .Where(s => s.TrainerId == trainerId && s.PaymentStatus == PaymentStatus.Completed)
        //                            .AsNoTracking()
        //                            .Include(s => s.Member)
        //                            .Include(m => m.Member.User)
        //                            .ToListAsync();
        //    return result;
        //}


        public async Task<List<Subscription>> GetTrainerSubscribers(Guid trainerId)
        {
            List<Subscription> result = await _context.Subscriptions
                                    .Where(s => s.TrainerId == trainerId && s.PaymentStatus == PaymentStatus.Completed)
                                    .AsNoTracking()
                                    .Include(s => s.Member)
                                    .Include(m => m.Member.User)
                                    .ToListAsync();
            return result;
        }

    }
}
