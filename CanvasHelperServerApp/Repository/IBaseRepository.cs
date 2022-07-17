using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CanvasHelperServerApp.Repository
{
    public interface IBaseRepository<T>
    {
        bool AddOrUpdate(T item);
        bool Remove(T item);
        T GetById(int Id);
        IQueryable<T> GetAll(Expression<Func<T, bool>> predicate = null);

    }
}
