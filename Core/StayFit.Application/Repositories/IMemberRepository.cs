using Microsoft.EntityFrameworkCore;
using StayFit.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StayFit.Application.Repositories
{
    public interface IMemberRepository : IGenericRepository<Member>
    {
        public Task<Member> GetMemberProfileAsync(Guid id);
        public Task<List<Member>> GetAllMembersIncludeUserAsync();
               
    }
}
