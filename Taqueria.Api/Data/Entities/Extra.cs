namespace Taqueria.Api.Data.Entities;

public class Extra
{
    public Guid Id { get; set; } = Guid.CreateVersion7();
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
}