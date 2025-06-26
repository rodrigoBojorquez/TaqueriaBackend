using Taqueria.Api.Data.Entities;
using Taqueria.Api.Services.Dish;

namespace Taqueria.Api.Common.Interfaces.Business;

public interface IDishService
{
    Task CreateAsync(string name, string? description, decimal price);
    
    Task<List<DishResult>> GetAllAsync();
    
    Task UpdateAsync(Guid id, string name, string? description, decimal price);
    
    Task DeleteAsync(Guid id);
    
    Task<DishResult?> GetByIdAsync(Guid id);
}