using film_api.data.Models;
using film_api.repository.BaseRepository.Abstract;
using System.Collections;

namespace film_api.repository.Abstract
{
    public interface IGenreRepository : IRepositoryBase<GenreDto>
    {
        public IEnumerable ListGenres();
        public void Add(string genre);
        public void Update(string genreToUpdate, string newGenre);
        public void Delete(string genre);
    }
}
