using film_api.data.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace film_api.repository
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        private readonly DatabaseContext dbContext;

        protected RepositoryBase(DatabaseContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Create(T entity)
        {
            dbContext.Set<T>().Add(entity);
            dbContext.SaveChanges();
        }

        public void Delete(T entity)
        {
            dbContext.Set<T>().Remove(entity);
            dbContext.SaveChanges();
        }

        public IQueryable<T> Get()
        {
            return dbContext.Set<T>().AsNoTracking();
        }

        public IQueryable<T> Get(Expression<Func<T, bool>> expression)
        {
            return dbContext.Set<T>().Where(expression).AsNoTracking();
        }

        public void Update(T entity)
        {
            dbContext.Set<T>().Update(entity);
            dbContext.SaveChanges();
        }
    }
}
