using film_api.data.Models;
using film_api.repository.Abstract;
using film_api.repository.BaseRepository.Concrete;
using System.Collections;

namespace film_api.repository.Concrete
{
    public class MovieRepository : RepositoryBase<MovieDto>, IMovieRepository
    {
        private readonly DatabaseContext dbContext;
        public MovieRepository(DatabaseContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        /// <summary>
        /// Get movies by genre
        /// First you might wanna take a look at some genres to test it (id:16 , name:"Animation")
        /// </summary>
        /// <param name="genreDto">Example : (id:16 , name:"Animation")</param>
        /// <returns></returns>
        public IEnumerable GetMovieListByGenre(GenreDto genreDto)
        {
            string genreDtoAsString = "{'id': " + genreDto.Id + ", 'name': '" + genreDto.Name + "'}";
            
            return dbContext.Movies.Take(1000).Where(x => x.Genres.Contains(genreDtoAsString));
        }

        /// <summary>
        /// Get movies by rate
        /// </summary>
        /// <param name="rate">Example : 7.7</param>
        /// <returns></returns>
        public IEnumerable GetMovieListByRate(decimal rate)
        {
            return dbContext.Movies.Take(1000).Where(x => x.VoteAverage == rate).ToList();
        }

        /// <summary>
        /// Get movies by release-date yyyy-mm-dd
        /// </summary>
        /// <param name="release_date">Example : 1995-10-30</param>
        /// <returns></returns>
        public IEnumerable GetMovieListByReleaseDate(string release_date)
        {
            return dbContext.Movies.Take(1000).Where(x => x.ReleaseDate == release_date).ToList();
        }

        /// <summary>
        /// Search by given parameters
        /// </summary>
        /// <param name="title">Toy Story</param>
        /// <param name="rate">7.7</param>
        /// <param name="date">1995-10-30</param>
        /// <returns></returns>
        public IEnumerable Search(string title, decimal rate, string date)
        {
            return dbContext.Movies.Take(1000).
                Where(x =>
                x.Title == title &&
                x.VoteAverage == rate &&
                x.ReleaseDate == date
                )
                .ToList();
        }
    }
}
