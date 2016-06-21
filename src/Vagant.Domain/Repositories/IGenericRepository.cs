using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Vagant.Domain.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        T GetByKey(object key);

        IEnumerable<T> Get(Expression<Func<T, bool>> filter);

        IEnumerable<T> GetAll();

        void Create(T entity);

        void Update(T entity);

        void Delete(T entity);
    }
}