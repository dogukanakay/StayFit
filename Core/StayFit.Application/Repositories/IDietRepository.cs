using StayFit.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StayFit.Application.Repositories
{
    public interface IDietRepository : IGenericRepository<Diet>
    {
        public Task AddRangeAsync(List<Diet> dietList);
    }
}
