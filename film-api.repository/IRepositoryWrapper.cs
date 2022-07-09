namespace film_api.repository
{
    public interface IRepositoryWrapper
    {
        IMovieRepository Movie { get; }
        IGenreRepository Genre { get; }
    }
}
