using UserAPI.Abstractions.Repositories;
using UserAPI.Abstractions.Repository;

namespace UserAPI.Abstractions.UnitOfWorks
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository UserR { get; }
        void Save();
    }
}
