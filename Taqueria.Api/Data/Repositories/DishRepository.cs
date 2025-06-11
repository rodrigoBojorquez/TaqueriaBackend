using Microsoft.EntityFrameworkCore;
using Taqueria.Api.Data.Entities;

namespace Taqueria.Api.Data.Repositories;

public class DishRepository: GenericRepository<Dish>
{
    private readonly TaqueriaDbContext _context;

    public DishRepository(TaqueriaDbContext context): base(context)
    {
        _context = context;
    }
    
}
