using StayFit.Domain.Entities;
using StayFit.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StayFit.Application.Repositories
{
    public interface IUserRepository : IGenericRepository<User> 
    {
    }
}
