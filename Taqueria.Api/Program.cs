using Microsoft.EntityFrameworkCore;
using Taqueria.Api.Common.Interfaces;
using Taqueria.Api.Data;
using Taqueria.Api.Data.Entities;
using Taqueria.Api.Data.Repositories;
using Taqueria.Api.Services.Dish;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();

// Metodo 2
builder.Services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<UserRepository>();
builder.Services.AddScoped<IDishRepository, DishRepository>();
builder.Services.AddScoped<DishService>();

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