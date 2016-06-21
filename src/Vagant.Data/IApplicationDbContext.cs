using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace Vagant.Data
{
    public interface IApplicationDbContext
    {
        DbSet<T> Set<T>() where T : class;

        DbEntityEntry<T> Entry<T>(T entity) where T : class;

        int SaveChanges();

        void Dispose();
    }
}
