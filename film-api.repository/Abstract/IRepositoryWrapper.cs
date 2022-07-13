namespace film_api.repository.Abstract
{
    public interface IRepositoryWrapper
    {
        IMovieRepository Movie { get; }
        IGenreRepository Genre { get; }
        ITrendingsRepository Trendings { get; }
    }
}
