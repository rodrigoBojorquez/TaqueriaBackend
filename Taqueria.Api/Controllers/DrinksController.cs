using Microsoft.AspNetCore.Mvc;
using Taqueria.Api.Common.Interfaces.Business;

namespace Taqueria.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DrinksController(IDrinkService drinkService) : ControllerBase
{
    public record CreateDrinkRequest(
        string Name,
        string? Description,
        decimal Price
    );
    
    public record UpdateDrinkRequest(
        string Name,
        string? Description,
        decimal Price
    );
    
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateDrinkRequest request)
    {
        await drinkService.CreateAsync(request.Name, request.Description, request.Price);
        return Ok("Bebida creada exitosamente");
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var drinks = await drinkService.GetAllAsync();
        return Ok(drinks);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateDrinkRequest request)
    {
        await drinkService.UpdateAsync(id, request.Name, request.Description, request.Price);
        return Ok("Bebida actualizada exitosamente");
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await drinkService.DeleteAsync(id);
        return Ok();
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var drink = await drinkService.GetByIdAsync(id);
        if (drink is null)
            return NotFound("Bebida no encontrada");
        return Ok(drink);
    }
}