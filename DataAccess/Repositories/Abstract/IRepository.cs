using System.Linq.Expressions;
using VideoManagementApi.Models;

namespace VideoManagementApi.DataAccess.Repositories.Abstract;

public interface IRepository<T>  where T : IEntity
{
    Task<List<T>> GetAllAsync(bool isActive);
    Task<List<T>> GetAllAsync(Expression<Func<T, bool>> filter = null);
    Task<bool> AddAsync(T entity);
    Task<T> GetByIdAsync(int id);
    Task<T> GetByFilterAsync(Expression<Func<T, bool>> filter = null);
    Task<bool> DeleteByIdAsync(int id);
    Task<bool> UpdateAsync(T entity);
}