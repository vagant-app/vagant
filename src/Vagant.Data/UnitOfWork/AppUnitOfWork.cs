using System;
using Vagant.Data.Repositories;
using Vagant.Domain.Repositories;
using Vagant.Domain.UnitOfWork;

namespace Vagant.Data.UnitOfWork
{
    public class AppUnitOfWork : IDisposable, IAppUnitOfWork
    {
        private readonly IApplicationDbContext _context;

        public AppUnitOfWork(IApplicationDbContext context)
        {
            _context = context;
        }

        public IGenericRepository<T> GetRepository<T>() where T : class
        {
            return new GenericRepository<T>(_context);
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            if (_context != null)
            {
                _context.Dispose();
            }
        }
    }
}