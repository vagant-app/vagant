using Vagant.Domain.Repositories;

namespace Vagant.Domain.UnitOfWork
{
    public interface IAppUnitOfWork
    {
        void Commit();

        IGenericRepository<T> GetRepository<T>() where T : class;
    }
}