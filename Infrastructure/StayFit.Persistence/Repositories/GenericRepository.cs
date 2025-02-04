using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using StayFit.Application.Repositories;
using StayFit.Domain.Entities.Common;
using StayFit.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace StayFit.Persistence.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity
    {

        private readonly StayFitDbContext _context;

        public GenericRepository(StayFitDbContext context)
        {
            _context = context;
        }

        public DbSet<TEntity> Table => _context.Set<TEntity>();

        public async Task<bool> AddAsync(TEntity entity)
        {
            EntityEntry entityEntry = await Table.AddAsync(entity);
            return entityEntry.State == EntityState.Added;
        }

        public async Task AddRangeAsync(List<TEntity> entities)
        {
            await _context.Set<TEntity>().AddRangeAsync(entities);
        }

        public async Task<List<TEntity>> GetAllAsync(bool tracking = true)
        {
            if (!tracking)
            {
                return await Table.AsNoTracking().ToListAsync();
            }
            return await Table.ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(object id, bool tracking = true)
        {
            if (id is Guid guidId)
            {
                return await Table.FindAsync(guidId);
            }
            else if (id is int intId)
            {
                return await Table.FindAsync(intId);
            }
            throw new ArgumentException("Invalid ID type");
        }



        public async Task<TEntity> GetSingleAsync(Expression<Func<TEntity, bool>> method, bool tracking = true)
        {
            if (!tracking)
            {
                return await Table.AsNoTracking().FirstOrDefaultAsync(method);
            }
            return await Table.FirstOrDefaultAsync(method);
        }

        public async Task<List<TEntity>> GetWhere(Expression<Func<TEntity, bool>> method, bool tracking = true)
        {
            if (!tracking)
            {
                return await Table.AsNoTracking().Where(method).ToListAsync();
            }
            return await Table.Where(method).ToListAsync();
        }

        public async Task<bool> Remove(TEntity entity)
        {
            EntityEntry entityEntry = Table.Remove(entity);
            return entityEntry.State == EntityState.Deleted;
        }

        public async Task<int> SaveAsync()
            => await _context.SaveChangesAsync();

        public bool Update(TEntity entity)
        {
            EntityEntry entityEntry = Table.Update(entity);
            return entityEntry.State == EntityState.Modified;
        }
    }
}
