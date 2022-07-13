using film_api.data.Models;
using film_api.repository.BaseRepository.Abstract;
using System.Collections;

namespace film_api.repository.Abstract
{
    public interface ITrendingsRepository : IRepositoryBase<MovieDto>
    {
        public IEnumerable ListMostViewedMovies();
        public IEnumerable ListTopRatedMovies();
    }
}
