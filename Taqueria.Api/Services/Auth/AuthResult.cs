namespace Taqueria.Api.Services.Auth;

public record AuthResult(
    Guid Id,
    string UserName,
    bool IsAuthenticated = true);