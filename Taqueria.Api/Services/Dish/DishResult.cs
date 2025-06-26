namespace Taqueria.Api.Services.Dish;

public record DishResult(
    Guid Id,
    string Name,
    decimal Price,
    string? Description = null,
    string? ImageUrl = null);