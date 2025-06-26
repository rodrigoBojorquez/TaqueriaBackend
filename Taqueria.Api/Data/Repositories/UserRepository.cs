using Microsoft.EntityFrameworkCore;
using Taqueria.Api.Common.Interfaces.Repositories;
using Taqueria.Api.Data.Entities;

namespace Taqueria.Api.Data.Repositories;

public class UserRepository(TaqueriaDbContext context) : GenericRepository<User>(context), IUserRepository
{
    private readonly TaqueriaDbContext _context = context;

    public async Task<User?> GetByEmailAsync(string email)
    {
        return await _context.Users
            .FirstOrDefaultAsync(u => u.Email == email);
    }
}
