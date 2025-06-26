using Taqueria.Api.Common.Interfaces.Business;
using Taqueria.Api.Common.Interfaces.Repositories;

namespace Taqueria.Api.Services.Drink;

public class DrinkService(IDrinkRepository drinkRepository) : IDrinkService
{
    public async Task CreateAsync(string name, string? description, decimal price)
    {
        var drink = new Data.Entities.Drink
        {
            Name = name,
            Description = description,
            Price = price
        };

        await drinkRepository.AddAsync(drink);
    }

    public async Task<List<DrinkResult>> GetAllAsync()
    {
        var drinks = await drinkRepository.GetAllAsync();
        return drinks.Select(d => d.ToDrinkResult()).ToList();
    }

    public async Task UpdateAsync(Guid id, string name, string? description, decimal price)
    {
        var drink = await drinkRepository.GetByIdAsync(id);
        if (drink == null)
        {
            throw new KeyNotFoundException("Drink not found");
        }

        drink.Name = name;
        drink.Description = description;
        drink.Price = price;

        await drinkRepository.UpdateAsync(drink);
    }

    public async Task DeleteAsync(Guid id)
    {
        await drinkRepository.HardDeleteAsync(id);
    }

    public async Task<DrinkResult?> GetByIdAsync(Guid id)
    {
        var drink = await drinkRepository.GetByIdAsync(id);
        return drink?.ToDrinkResult();
    }
}