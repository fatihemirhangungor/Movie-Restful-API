using film_api.data;
using film_api.data.Redis;
using Microsoft.EntityFrameworkCore;


namespace film_api.repository
{
    public class MovieRepository : IMovieRepository
    {
        private readonly MovieDataContext _movieDataContext;
        private readonly IRedisHelper _redisHelper;

        public MovieRepository(MovieDataContext movieDataContext, IRedisHelper redisHelper)
        {
            _movieDataContext = movieDataContext;
            _redisHelper = redisHelper;
        }

        public async Task<Movie> Create(Movie movie)
        {
            _movieDataContext.Add(movie);
            await _movieDataContext.SaveChangesAsync();

            //await _redisHelper.SetKeyAsync("lastmovieid", movie.Id.ToString());

            return movie;
        }

        public async Task Delete(int id)
        {
            var movieToDelete = await _movieDataContext.Movies.FindAsync(id);
            _movieDataContext.Movies.Remove(movieToDelete);
            await _movieDataContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Movie>> Get()
        {
            return await _movieDataContext.Movies.ToListAsync();
        }

        public async Task<Movie> Get(int id)
        {
            var lastMovieId = await _redisHelper.GetKeyAsync("lastmovieid");

            return await _movieDataContext.Movies.FindAsync(id);
        }

        public async Task Update(Movie movie)
        {
            _movieDataContext.Entry(movie).State = EntityState.Modified;
            await _movieDataContext.SaveChangesAsync();
        }
    }
}
