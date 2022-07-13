using film_api.data.Models;
using film_api.repository.BaseRepository.Abstract;
using System.Collections;

namespace film_api.repository.Abstract
{
    public interface IMovieRepository : IRepositoryBase<MovieDto>
    {
        public IEnumerable GetMovieListByGenre(GenreDto genreDto);
        public IEnumerable GetMovieListByRate(decimal rate);
        public IEnumerable GetMovieListByReleaseDate(string date);
        public IEnumerable Search(string title, decimal rate, string date);
    }
}
