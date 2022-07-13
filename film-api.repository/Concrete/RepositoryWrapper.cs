using film_api.data.Models;
using film_api.repository.Abstract;

namespace film_api.repository.Concrete
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private DatabaseContext _dbContext;
        private IMovieRepository _movie;
        private IGenreRepository _genre;
        private ITrendingsRepository _trendings;

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

        public ITrendingsRepository Trendings
        {
            get
            {
                if (_trendings == null)
                {
                    _trendings = new TrendingsRepository(_dbContext);
                }
                return _trendings;
            }
        }
        public RepositoryWrapper(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
