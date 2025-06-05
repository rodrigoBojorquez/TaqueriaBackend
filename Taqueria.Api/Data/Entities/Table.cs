namespace Taqueria.Api.Data.Entities;

public class Table
{
    public Guid Id { get; set; } = Guid.CreateVersion7();
    public int Number { get; set; }
}