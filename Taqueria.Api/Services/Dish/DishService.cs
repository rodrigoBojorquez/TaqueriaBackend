namespace Taqueria.Api.Services.Dish;

public class DishService(IDishRepository dishRepository)
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
}