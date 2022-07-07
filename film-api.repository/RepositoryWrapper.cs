using film_api.data.Models;

namespace film_api.repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private DatabaseContext _dbContext;
        private IMovieRepository _movie;

        public IMovieRepository Movie
        {
            get
            {
                if (_movie == null)
                {
                    _movie = new MovieRepository(_dbContext);
                }
                return _movie;
            }
        }

        public RepositoryWrapper(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
