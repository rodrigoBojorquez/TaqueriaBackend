using Microsoft.EntityFrameworkCore;
using Taqueria.Api.Common.Interfaces;
using Taqueria.Api.Common.Interfaces.Repositories;
using Taqueria.Api.Data.Entities;
using Taqueria.Api.Services.Dish;

namespace Taqueria.Api.Data.Repositories;

public class DishRepository(TaqueriaDbContext context) : GenericRepository<Dish>(context), IDishRepository
{
    private readonly TaqueriaDbContext _context = context;
}
