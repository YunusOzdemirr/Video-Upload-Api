using System;
using System.Linq.Expressions;

namespace VideoManagementApi.Application.Interfaces.Repositories
{
    public interface IGenericRepository<T> : IRepository<T> where T : BaseEntity
    {
        Task<List<T>> GetAllAsync(bool isActive);
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>> filter = null);
        Task<bool> AddAsync(T entity);
        Task<T> GetByIdAsync(int id);
        Task<T> GetByFilterAsync(Expression<Func<T, bool>> filter = null);
        Task<bool> DeleteByIdAsync(int id);
        Task<bool> UpdateAsync(T entity);
    }
}