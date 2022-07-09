using film_api.data.Models;

namespace film_api.repository
{
    public class MovieRepository : RepositoryBase<MovieDto>, IMovieRepository
    {
        public MovieRepository(DatabaseContext dbContext) : base(dbContext)
        {
        }
    }
}
