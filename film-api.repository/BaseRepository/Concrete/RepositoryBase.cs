using film_api.data.Models;
using film_api.repository.BaseRepository.Abstract;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace film_api.repository.BaseRepository.Concrete
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        private readonly DatabaseContext dbContext;

        protected RepositoryBase(DatabaseContext dbContext)
        {
            this.dbContext = dbContext;
        }

        /// <summary>
        /// Add new entity
        /// </summary>
        /// <param name="entity"></param>
        public void Create(T entity)
        {
            dbContext.Set<T>().Add(entity);
            dbContext.SaveChanges();
        }

        /// <summary>
        /// Delete entity
        /// </summary>
        /// <param name="entity"></param>
        public void Delete(T entity)
        {
            dbContext.Set<T>().Remove(entity);
            dbContext.SaveChanges();
        }

        /// <summary>
        /// Get
        /// </summary>
        /// <returns></returns>
        public IQueryable<T> Get()
        {
            //return dbContext.Set<T>().AsNoTracking();
            var result = dbContext.Set<T>().AsNoTracking();
            return result.Take(100);
        }

        /// <summary>
        /// Get by expression like (get by id)
        /// </summary>
        /// <param name="expression">Get by id</param>
        /// <returns></returns>
        public IQueryable<T> Get(Expression<Func<T, bool>> expression)
        {
            return dbContext.Set<T>().Where(expression).AsNoTracking();
        }

        /// <summary>
        /// Update entity
        /// </summary>
        /// <param name="entity"></param>
        public void Update(T entity)
        {
            dbContext.Set<T>().Update(entity);
            dbContext.SaveChanges();
        }
    }
}
