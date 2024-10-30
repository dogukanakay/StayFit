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
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(StayFitDbContext context) : base(context)
        {
        }
    }
}
