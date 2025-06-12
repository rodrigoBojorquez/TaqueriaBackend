using Microsoft.EntityFrameworkCore;
using Taqueria.Api.Common.Interfaces;
using Taqueria.Api.Data.Entities;
using Taqueria.Api.Services.Dish;

namespace Taqueria.Api.Data.Repositories;

public class DishRepository: GenericRepository<Dish>, IDishRepository
{
    private readonly TaqueriaDbContext _context;

    public DishRepository(TaqueriaDbContext context): base(context)
    {
        _context = context;
    }
    
}
