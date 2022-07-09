using film_api.data.Models;
using System.Collections;

namespace film_api.repository
{
    public interface IGenreRepository : IRepositoryBase<GenreDto>
    {
        public IEnumerable ListGenres();
        public void Add(GenreDto genre);
        public void Update(GenreDto genreToUpdate, GenreDto newGenre);
        public void Delete(GenreDto genre);
    }
}
