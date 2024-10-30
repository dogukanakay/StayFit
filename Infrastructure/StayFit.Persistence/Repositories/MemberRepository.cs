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
    public class MemberRepository : GenericRepository<Member>, IMemberRepository
    {
        private readonly StayFitDbContext _context;
        public MemberRepository(StayFitDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Member> GetMemberProfile(Guid id)
            => await _context.Members.Include(m => m.User).FirstOrDefaultAsync(m=>m.Id==id);
    }
}
