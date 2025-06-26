namespace Taqueria.Api.Services.Dish;

public static class DishExtensions
{
    public static DishResult ToDishResult(this Data.Entities.Dish dish)
    {
        return new DishResult(
            dish.Id,
            dish.Name,
            dish.Price,
            dish.Description,
            dish.ImageUrl);
    }
}