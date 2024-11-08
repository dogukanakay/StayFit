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

        public async Task<GetMemberSubscribedTrainerDto> GetMemberSubscribedTrainer(Guid memberId)
        {

            return await _context.Subscriptions
                                       .Where(s => s.MemberId == memberId && s.PaymentStatus == PaymentStatus.Completed)
                                       .Select(s => new GetMemberSubscribedTrainerDto
                                       {
                                           Amount = s.Amount,
                                           EndDate = s.EndDate,
                                           FirstName = s.Trainer.User.FirstName,
                                           LastName = s.Trainer.User.LastName,
                                           PhotoPath = s.Trainer.User.PhotoPath,
                                           SubscriptionId = s.Id,
                                           TrainerId = s.TrainerId
                                       })
                                       .FirstOrDefaultAsync();

        }

        public async Task<List<GetTrainerSubscribersDto>> GetTrainerSubscribers(Guid trainerId)
        {
            return await _context.Subscriptions
                                    .Where(s => s.TrainerId == trainerId && s.PaymentStatus == PaymentStatus.Completed)
                                    .Select(s => new GetTrainerSubscribersDto
                                    {
                                        Amount = s.Amount,
                                        EndDate = s.EndDate,
                                        BirthDate = s.Member.User.BirthDate,
                                        FirstName = s.Member.User.FirstName,
                                        LastName = s.Member.User.LastName,
                                        Gender = s.Member.User.Gender,
                                        Height = s.Member.Height,
                                        Id = s.Id,
                                        MemberId = s.MemberId,
                                        PhotoPath = s.Member.User.PhotoPath,
                                        Weight = s.Member.Weight

                                    }).ToListAsync();
        }

    }
}
