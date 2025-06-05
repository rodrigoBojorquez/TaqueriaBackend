namespace Taqueria.Api.Data.Entities;

public class OrderDrink
{
    public Guid Id { get; set; } = Guid.CreateVersion7();
    
    public Guid OrderId { get; set; }
    
    public Guid DrinkId { get; set; }
}