using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Taqueria.Api.Data.Entities;

namespace Taqueria.Api.Data;

public class TaqueriaDbContext(DbContextOptions<TaqueriaDbContext> options) : DbContext(options)
{
    public DbSet<Dish> Dishes { get; set; }
    public DbSet<Drink> Drinks { get; set; }
    public DbSet<Extra> Extras { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderDish> OrderDish { get; set; }
    public DbSet<OrderDishExtra> OrderDishExtra { get; set; }
    public DbSet<OrderDrink> OrderDrink { get; set; }
    public DbSet<Table> Tables { get; set; }
    public DbSet<User> Users { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}