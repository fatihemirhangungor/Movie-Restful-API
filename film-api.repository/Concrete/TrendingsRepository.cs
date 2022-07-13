using film_api.data.Models;
using film_api.repository.Abstract;
using film_api.repository.BaseRepository.Concrete;
using System.Collections;

namespace film_api.repository.Concrete
{
    public class TrendingsRepository : RepositoryBase<MovieDto>, ITrendingsRepository
    {
        private readonly DatabaseContext dbContext;

        public TrendingsRepository(DatabaseContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public IEnumerable ListMostViewedMovies()
        {
            return dbContext.Movies.Take(1000).OrderByDescending(x => x.Popularity).Take(10).ToList();
        }

        public IEnumerable ListTopRatedMovies()
        {
            return dbContext.Movies.Take(1000).OrderByDescending(x => x.VoteAverage).Take(10).ToList();
        }
    }
}
