using UserAPI.Abstractions.Repository;
using UserAPI.Entities;

namespace UserAPI.Abstractions.Repositories;

public interface IUserRepository : IGenericRepository<User>
{
}