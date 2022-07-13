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

        public IEnumerable GetMovieListByGenre(GenreDto genreDto)
        {
            string genreDtoAsString = "{'id': " + genreDto.Id + ", 'name': '" + genreDto.Name + "'}";
            
            return dbContext.Movies.Take(1000).Where(x => x.Genres.Contains(genreDtoAsString));
        }

        public IEnumerable GetMovieListByRate(decimal rate)
        {
            return dbContext.Movies.Take(1000).Where(x => x.VoteAverage == rate).ToList();
        }
        public IEnumerable GetMovieListByReleaseDate(string release_date)
        {
            return dbContext.Movies.Take(1000).Where(x => x.ReleaseDate == release_date).ToList();
        }

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
