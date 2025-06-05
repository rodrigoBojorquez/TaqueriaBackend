namespace Taqueria.Api.Data.Entities;

public class OrderDishExtra
{
    public Guid Id { get; set; } = Guid.CreateVersion7();
    public Guid OrderDishId { get; set; }
    public Guid ExtraId { get; set; }
}