using film_api.repository;

namespace film_api.Services
{
    public class FillGenreListAtBeginningService
    {
        private readonly IGenreRepository genreRepository;

        public FillGenreListAtBeginningService(IGenreRepository genreRepository)
        {
            this.genreRepository = genreRepository;
        }

        public void FillGenreList()
        {
            genreRepository.ListGenres();
        }
    }
}
