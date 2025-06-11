using Microsoft.EntityFrameworkCore;
using Taqueria.Api.Data.Entities;

namespace Taqueria.Api.Data.Repositories;

public class UserRepository: GenericRepository<User>
{
    private readonly TaqueriaDbContext _context;

    public UserRepository(TaqueriaDbContext context): base(context)
    {
        _context = context;
    }
    
}
