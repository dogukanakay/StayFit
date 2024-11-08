using StayFit.Application.DTOs;
using StayFit.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StayFit.Application.Repositories
{
    public interface ISubscriptionRepository : IGenericRepository<Subscription>
    {
        Task<List<GetTrainerSubscribersDto>> GetTrainerSubscribers(Guid trainerId);
        Task<GetMemberSubscribedTrainerDto> GetMemberSubscribedTrainer(Guid memberId);
    }
}
