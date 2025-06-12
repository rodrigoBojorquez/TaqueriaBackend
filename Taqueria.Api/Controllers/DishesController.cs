using Microsoft.AspNetCore.Mvc;
using Taqueria.Api.Services.Dish;

namespace Taqueria.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DishesController(DishService dishService) : ControllerBase
{
    public record CreateDishRequest(
        string Name,
        string? Description,
        decimal Price
    );
    
    
    [HttpPost]
    public async Task<IActionResult> CreateDish([FromBody] CreateDishRequest request)
    {
        await dishService.CreateAsync(
            request.Name,
            request.Description,
            request.Price
        );
        return Ok("Platillo creado exitosamente");
    }
}