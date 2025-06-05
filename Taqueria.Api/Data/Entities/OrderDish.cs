namespace Taqueria.Api.Data.Entities;

public class OrderDish
{
    public Guid Id { get; set; } = Guid.CreateVersion7();
    
    public Guid OrderId { get; set; }
    
    public Guid DishId { get; set; }
}