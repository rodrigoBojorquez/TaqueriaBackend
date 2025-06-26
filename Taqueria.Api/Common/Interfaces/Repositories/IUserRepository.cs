using Taqueria.Api.Data.Entities;

namespace Taqueria.Api.Common.Interfaces.Repositories;

public interface IUserRepository : IRepository<User>
{
    Task<User?> GetByEmailAsync(string email);
}