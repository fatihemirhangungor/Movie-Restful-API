using film_api.data.Models;

namespace film_api.repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private DatabaseContext _dbContext;
        private IMovieRepository _movie;
        private IGenreRepository _genre;

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
        public IGenreRepository Genre
        {
            get
            {
                if (_genre == null)
                {
                    _genre = new GenreRepository(_dbContext);
                }
                return _genre;
            }
        }

        public RepositoryWrapper(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
