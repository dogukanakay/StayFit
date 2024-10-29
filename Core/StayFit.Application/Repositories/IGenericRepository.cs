using Microsoft.EntityFrameworkCore;
using StayFit.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace StayFit.Application.Repositories
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        DbSet<T> Table { get; }
        Task<List<T>> GetAllAsync(bool tracking = true);
        Task<List<T>> GetWhere(Expression<Func<T, bool>> method, bool tracking = true);
        Task<T> GetSingleAsync(Expression<Func<T, bool>> method, bool tracking = true);
        Task<T> GetByIdAsync(object id, bool tracking = true);
        Task<bool> AddAsync(T entity);
        Task<bool> Remove(T entity);
        bool Update(T entity);
        Task<int> SaveAsync();
    }
}
