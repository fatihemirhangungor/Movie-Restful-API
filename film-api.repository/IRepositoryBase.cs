using System.Collections;
using System.Linq.Expressions;

namespace film_api.repository
{
    public interface IRepositoryBase<T>
    {
        IQueryable<T> Get();
        IQueryable<T> Get(Expression<Func<T, bool>> expression);
        public void Create(T entity);
        public void Update(T entity);
        public void Delete(T entity);
        //public IEnumerable ListGenres();
    }
}
