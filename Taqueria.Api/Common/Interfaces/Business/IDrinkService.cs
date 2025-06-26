using Taqueria.Api.Data.Entities;
using Taqueria.Api.Services.Drink;

namespace Taqueria.Api.Common.Interfaces.Business;

public interface IDrinkService
{
    Task CreateAsync(string name, string? description, decimal price);
    
    Task<List<DrinkResult>> GetAllAsync();
    
    Task UpdateAsync(Guid id, string name, string? description, decimal price);
    
    Task DeleteAsync(Guid id);
    
    Task<DrinkResult?> GetByIdAsync(Guid id);
}