using Microsoft.EntityFrameworkCore;
using Taqueria.Api.Common.Interfaces;
using Taqueria.Api.Common.Interfaces.Repositories;
using Taqueria.Api.Data.Entities;

namespace Taqueria.Api.Data.Repositories;

public class GenericRepository<T>(TaqueriaDbContext context) : IRepository<T>
    where T : class
{
    public async Task<T?> GetByIdAsync(Guid id)
    {
        return await context.Set<T>().FindAsync(id);
    }

    public async Task<List<T>> GetAllAsync()
    {
        return await context.Set<T>().ToListAsync();
    }
    
    public async Task AddAsync(T entity)
    {
        await context.Set<T>().AddAsync(entity);
        await context.SaveChangesAsync();
    }
    
    public async Task UpdateAsync(T updateEntity)
    {
        context.Set<T>().Attach(updateEntity);
        context.Entry(updateEntity).State = EntityState.Modified;
        await context.SaveChangesAsync();
        await context.Entry(updateEntity).ReloadAsync();
    }
    
    public async Task HardDeleteAsync(Guid id)
    {
        T? entity = await context.Set<T>().FindAsync(id);

        if (entity != null) context.Set<T>().Remove(entity);
        await context.SaveChangesAsync();
    }

    
}
