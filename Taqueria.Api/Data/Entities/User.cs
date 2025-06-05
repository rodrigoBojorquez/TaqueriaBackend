namespace Taqueria.Api.Data.Entities;

public class User
{
    public Guid Id { get; set; } = Guid.CreateVersion7();
    public string UserName { get; set; } = string.Empty;
    public required string Email { get; set; }
    public required string Password { get; set; }
}