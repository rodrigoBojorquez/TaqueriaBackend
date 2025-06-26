using Taqueria.Api.Common.Interfaces.Repositories;
using Taqueria.Api.Data.Entities;

namespace Taqueria.Api.Data.Repositories;

public class DrinkRepository(TaqueriaDbContext context) : GenericRepository<Drink>(context), IDrinkRepository
{
    
};