using film_api.repository.Abstract;

namespace film_api.repository.BaseRepository.Abstract
{
    public interface IRepositoryWrapper
    {
        IMovieRepository Movie { get; }
        IGenreRepository Genre { get; }
        ITrendingsRepository Trendings { get; }
    }
}
