using UserAPI.Abstractions.Repositories;
using UserAPI.Abstractions.UnitOfWorks;
using UserAPI.Contexts;
using UserAPI.Implementations.Repositories;

namespace UserAPI.Implementations.UnitOfWorks;

public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly ApplicationDbContext _context;

    public UnitOfWork(ApplicationDbContext context)
    {
        _context = context;
        UserR = new UserRepository(_context);
    }

    public IUserRepository UserR { get; }

    public void Dispose()
    {
        _context.Dispose();
    }

    public void Save()
    {
        _context.SaveChanges();
    }
}