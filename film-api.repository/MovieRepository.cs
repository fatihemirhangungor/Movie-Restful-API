using film_api.data.Models;
using film_api.data.Redis;
using Microsoft.EntityFrameworkCore;


namespace film_api.repository
{
    public class MovieRepository : RepositoryBase<MovieDto>, IMovieRepository
    {
        public MovieRepository(DatabaseContext dbContext) : base(dbContext)
        {
        }
    }
}
