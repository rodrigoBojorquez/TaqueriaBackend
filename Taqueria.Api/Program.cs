using Microsoft.EntityFrameworkCore;
using Taqueria.Api.Common.Interfaces.Auth;
using Taqueria.Api.Common.Interfaces.Business;
using Taqueria.Api.Common.Interfaces.Repositories;
using Taqueria.Api.Data;
using Taqueria.Api.Data.Repositories;
using Taqueria.Api.Services.Auth;
using Taqueria.Api.Services.Dish;
using Taqueria.Api.Services.Drink;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();

// Repositorios
builder.Services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IDishRepository, DishRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IDrinkRepository, DrinkRepository>();

// Servicios
builder.Services.AddScoped<IDishService, DishService>();
builder.Services.AddScoped<IDrinkService, DrinkService>();
builder.Services.AddScoped<IAuthService, AuthService>();

// Configuiracion de Contexto de Base de Datos
builder.Services.AddDbContext<TaqueriaDbContext>(options =>
{
    var cs = builder.Configuration.GetConnectionString("TaqueriaConnection");
    options.UseSqlite(cs);
});

var app = builder.Build();

app.MapOpenApi();
app.UseSwaggerUI(config => { config.SwaggerEndpoint("/openapi/v1.json", "Taqueria API"); });

await using (var scope = app.Services.CreateAsyncScope())
await using (var dbContext = scope.ServiceProvider.GetRequiredService<TaqueriaDbContext>())
{
    
    await dbContext.Database.EnsureCreatedAsync();
}


app.Lifetime.ApplicationStarted.Register(() =>
{
    var addresses = app.Urls;
    var logger = app.Services.GetRequiredService<ILogger<Program>>();
    
    logger.LogInformation("Swagger UI is available at {SwaggerUrl}", $"{addresses.First()}/swagger/index.html");
});

app.UseHttpsRedirection();

app.MapControllers();

app.Run();