using Microsoft.AspNetCore.Mvc;
using Taqueria.Api.Common.Interfaces.Auth;

namespace Taqueria.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController(IAuthService authService) : ControllerBase
{
    public record LoginRequest(
        string Email,
        string Password
    );
    
    public record RegisterRequest(
        string UserName,
        string Email,
        string Password
    );
    
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        var result = await authService.LoginAsync(request.Email, request.Password);
        if (result is null)
            return Unauthorized("Credenciales incorrectas");
        return Ok(result);
    }
    
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterRequest request)
    {
        await authService.RegisterAsync(request.Email, request.Password, request.UserName);
        return Ok("Registro exitoso");
    }
}