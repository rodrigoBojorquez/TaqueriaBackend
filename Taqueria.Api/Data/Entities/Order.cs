namespace Taqueria.Api.Data.Entities;

public class Order
{
    public Guid Id { get; set; } = Guid.CreateVersion7();
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public OrderStatus Status { get; set; } = OrderStatus.Pending;
    public string? Notes { get; set; }
}

public enum OrderStatus
{
    Pending,
    InProgress,
    Completed,
    Cancelled
}