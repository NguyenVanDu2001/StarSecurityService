using StarSecurityService.ApplicationCore.InterFaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StarSecurityService.EntityFramework.Data
{
    public class EfRepository<T> : IAsyncRepository<T> where T : class
    {
        protected readonly StarServiceDbContext _dbContext;

        public EfRepository(StarServiceDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IQueryable<T>> GetAllAsync()
        {
            return _dbContext.Set<T>();
        }
        public virtual async Task<T> GetByIdAsync(int id)
        {
            var keyValues = new object[] { id };
            return await _dbContext.Set<T>().FindAsync(keyValues);
        }

        public async Task<IReadOnlyList<T>> ListAllAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task<IReadOnlyList<T>> ListAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbContext.Set<T>().Where(predicate).ToListAsync();
        }

        public async Task<int> CountAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbContext.Set<T>().Where(predicate).CountAsync();
        }

        public async Task<T> AddAsync(T entity)
        {
             _dbContext.Set<T>().Add(entity);
             _dbContext.SaveChanges();
            return entity;
        }

        public async Task UpdateAsync(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
             _dbContext.SaveChanges();
        }

        public async Task DeleteAsync(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            _dbContext.SaveChanges();
        }

        public async Task<T> FirstAsync(Expression<Func<T, bool>> predicate)
        {
            return _dbContext.Set<T>().Where(predicate).First();
        }

        public async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate)
        {
            return _dbContext.Set<T>().Where(predicate).FirstOrDefault();
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);

            GC.SuppressFinalize(this);
        }

        public async Task<ICollection<T>> GetAllListAsync()
        {
          return  await _dbContext.Set<T>().ToListAsync();
        }

        public async Task<IQueryable<T>> GetAllAsync(Expression<Func<T, bool>> predicate)
        {
           return   _dbContext.Set<T>().Where(predicate);
        }
    }
}
