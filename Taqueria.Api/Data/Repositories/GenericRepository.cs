using Microsoft.EntityFrameworkCore;
using Taqueria.Api.Data.Entities;

namespace Taqueria.Api.Data.Repositories;

public class GenericRepository<T>
    where T : class
{
    private readonly TaqueriaDbContext _dbContext;

    public GenericRepository(TaqueriaDbContext context)
    {
        _dbContext = context;
    }
    
    public virtual async Task<T?> GetByIdAsync(Guid id)
    {
        return await _dbContext.Set<T>().FindAsync(id);
    }

    public virtual async Task<List<T>> GetAllAsync()
    {
        return await _dbContext.Set<T>().ToListAsync();
    }
    
    public virtual async Task<T> AddAsync(T entity)
    {
        await _dbContext.Set<T>().AddAsync(entity);
        await _dbContext.SaveChangesAsync();
        return entity;
    }
    
    public virtual async Task<T?> UpdateAsync(Guid id, T updateEntity)
    {
        T? entity = await _dbContext.Set<T>().FindAsync(id);
        
        if(entity == null)
        {
             return null;
        }
        
        _dbContext.Entry(entity).CurrentValues.SetValues(updateEntity);
        
        await _dbContext.SaveChangesAsync();
        return entity;
    }
    
    public virtual async Task<bool> HardDeleteAsync(Guid id)
    {
        T? entity = await _dbContext.Set<T>().FindAsync(id);
        
        if(entity == null)
        {
            return false;
        }
        
        _dbContext.Set<T>().Remove(entity);
        await _dbContext.SaveChangesAsync();
        return true;
    }

    
}
