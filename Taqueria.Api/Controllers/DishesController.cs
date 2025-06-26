using Microsoft.AspNetCore.Http.HttpResults;
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
    
    public record UpdateDishRequest(
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
    
    [HttpGet]
    public async Task<IActionResult> GetAllDishes()
    {
        var dishes = await dishService.GetAllAsync();
        return Ok(dishes);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update([FromBody] UpdateDishRequest request, Guid id)
    {
        // Implement update logic here
        await dishService.UpdateAsync(id, request.Name, request.Description, request.Price);
        return Ok();
    }
    
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await dishService.DeleteAsync(id);
        return Ok("Platillo eliminado exitosamente");
    }
}