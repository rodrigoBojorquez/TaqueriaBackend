using Microsoft.EntityFrameworkCore;
using Taqueria.Api.Common.Interfaces;
using Taqueria.Api.Data.Entities;

namespace Taqueria.Api.Data.Repositories;

public class GenericRepository<T> : IRepository<T>
    where T : class
{
    private readonly TaqueriaDbContext _dbContext;

    public GenericRepository(TaqueriaDbContext context)
    {
        _dbContext = context;
    }
    
    public async Task<T?> GetByIdAsync(Guid id)
    {
        return await _dbContext.Set<T>().FindAsync(id);
    }

    public async Task<List<T>> GetAllAsync()
    {
        return await _dbContext.Set<T>().ToListAsync();
    }
    
    public async Task AddAsync(T entity)
    {
        await _dbContext.Set<T>().AddAsync(entity);
        await _dbContext.SaveChangesAsync();
    }
    
    public async Task UpdateAsync(T updateEntity)
    {
        _dbContext.Set<T>().Attach(updateEntity);
        _dbContext.Entry(updateEntity).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
        await _dbContext.Entry(updateEntity).ReloadAsync();
    }
    
    public async Task HardDeleteAsync(Guid id)
    {
        T? entity = await _dbContext.Set<T>().FindAsync(id);
        
        _dbContext.Set<T>().Remove(entity);
        await _dbContext.SaveChangesAsync();
    }

    
}
