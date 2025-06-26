namespace Taqueria.Api.Services.Drink;

public static class DrinkExtensions
{
    public static DrinkResult ToDrinkResult(this Data.Entities.Drink drink)
    {
        return new DrinkResult(
            drink.Id,
            drink.Name,
            drink.Price,
            drink.Description);
    }
}