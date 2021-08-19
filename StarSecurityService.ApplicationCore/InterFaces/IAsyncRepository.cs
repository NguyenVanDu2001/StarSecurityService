using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StarSecurityService.ApplicationCore.InterFaces
{
    public interface IAsyncRepository<T> : IDisposable where T : class
    {
        Task<T> GetByIdAsync(int id);
        T GetById(int id);
        T GetByIdAsNoTracking(Expression<Func<T, bool>> predicate);
        Task<IReadOnlyList<T>> ListAllAsync();
        Task<IReadOnlyList<T>> ListAsync(Expression<Func<T, bool>> predicate);
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task<int> CountAsync(Expression<Func<T, bool>> predicate);
        Task<T> FirstAsync(Expression<Func<T, bool>> predicate);
        Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate);
        Task<IQueryable<T>> GetAllAsync();
        Task<IQueryable<T>> GetAllInclueAsync(params Expression<Func<T, object>>[] includes);
        Task<IQueryable<T>> GetAllAsync(Expression<Func<T, bool>> predicate);
        Task<ICollection<T>> GetAllListAsync();
        IQueryable<T> GetAll();
    }
}
