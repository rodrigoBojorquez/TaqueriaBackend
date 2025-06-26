using Taqueria.Api.Services.Auth;

namespace Taqueria.Api.Common.Interfaces.Auth;

public interface IAuthService
{
    Task<AuthResult?> LoginAsync(string email, string password);
    Task RegisterAsync(string email, string password, string userName);
}