using Taqueria.Api.Common.Interfaces.Auth;
using Taqueria.Api.Common.Interfaces.Repositories;

namespace Taqueria.Api.Services.Auth;

public class AuthService(IUserRepository userRepository) : IAuthService
{
    public async Task<AuthResult?> LoginAsync(string email, string password)
    {
        var user = await userRepository.GetByEmailAsync(email);
        if (user is null || !BCrypt.Net.BCrypt.Verify(password, user.Password))
            return null;
        
        return new AuthResult(user.Id, user.UserName);
    }

    public async Task RegisterAsync(string email, string password, string userName)
    {
        var existingUser = await userRepository.GetByEmailAsync(email);
        if (existingUser is not null)
        {
            throw new InvalidOperationException("User with this email already exists.");
        }

        var user = new Data.Entities.User
        {
            Email = email,
            // Hash de contraseña con BCrypt
            Password = BCrypt.Net.BCrypt.HashPassword(password),
            UserName = userName
        };

        await userRepository.AddAsync(user);
    }
}