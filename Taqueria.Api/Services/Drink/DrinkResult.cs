namespace Taqueria.Api.Services.Drink;

public record DrinkResult(
    Guid Id,
    string Name,
    decimal Price,
    string? Description = null);