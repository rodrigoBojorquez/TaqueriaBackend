using Taqueria.Api.Common.Interfaces.Business;
using Taqueria.Api.Common.Interfaces.Repositories;

namespace Taqueria.Api.Services.Dish;

public class DishService(IDishRepository dishRepository) : IDishService
{
        public async Task CreateAsync(string name, string? description, decimal price)
    {
        var dish = new Data.Entities.Dish
        {
            Name = name,
            Description = description,
            Price = price
        };

        await dishRepository.AddAsync(dish);
    }
    
    public async Task<List<DishResult>> GetAllAsync()
    {
        var data=  await dishRepository.GetAllAsync();
        return data.Select(d => d.ToDishResult()).ToList();
    }
    
    public async Task UpdateAsync(Guid id, string name, string? description, decimal price)
    {
        var dish = await dishRepository.GetByIdAsync(id);
        if (dish == null)
        {
            throw new KeyNotFoundException("Dish not found");
        }

        dish.Name = name;
        dish.Description = description;
        dish.Price = price;

        await dishRepository.UpdateAsync(dish);
    }
    
    public async Task DeleteAsync(Guid id)
    {
        await dishRepository.HardDeleteAsync(id);
    }

    public async Task<DishResult?> GetByIdAsync(Guid id)
    {
        var dish = await dishRepository.GetByIdAsync(id);
        return dish?.ToDishResult();
    }
}