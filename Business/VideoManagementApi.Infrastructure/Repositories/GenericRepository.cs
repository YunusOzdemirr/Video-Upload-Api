using System;
using System.Linq.Expressions;
using VideoManagementApi.Domain.Common;
using VideoManagementApi.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace VideoManagementApi.Infrastructure.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
{
    private VideoContext _context;
    public IUnitOfWork UnitOfWork => _context;

    public GenericRepository(VideoContext context)
    {
        _context = context;
    }

    public virtual async Task<bool> AddAsync(T entity, CancellationToken cancellationToken)
    {
        await _context.AddAsync(entity, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }

    public virtual async Task<bool> DeleteByIdAsync(int id, CancellationToken cancellationToken)
    {
        var entity = await _context.Set<T>().FirstOrDefaultAsync(a => a.Id.Equals(id), cancellationToken);
        if (entity == null)
            return false;
        _context.Remove(entity);
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }

    public virtual async Task<List<T>> GetAllAsync(bool isActive, CancellationToken cancellationToken)
    {
        var result = await _context.Set<T>().Where(a => a.IsActive == isActive).ToListAsync(cancellationToken);
        return result;
    }

    public virtual async Task<List<T>> GetAllAsync(Expression<Func<T, bool>> filter = null,
        CancellationToken cancellationToken = default)
    {
        return filter == null
            ? await _context.Set<T>().ToListAsync(cancellationToken)
            : await _context.Set<T>().Where(filter).ToListAsync(cancellationToken);
    }

    public virtual async Task<T> GetByFilterAsync(Expression<Func<T, bool>> filter = null,
        CancellationToken cancellationToken = default)
    {
        return await _context.Set<T>().SingleOrDefaultAsync(filter, cancellationToken);
    }

    public virtual async Task<T> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        return await _context.Set<T>().SingleOrDefaultAsync(a => a.Id.Equals(id),cancellationToken);
    }

    public virtual async Task<bool> UpdateAsync(T entity, CancellationToken cancellationToken)
    {
        _context.Entry<T>(entity).State = EntityState.Modified;
        entity.ModifiedDate = DateTime.Now;
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }
}