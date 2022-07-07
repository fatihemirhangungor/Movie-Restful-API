using film_api.data;
using film_api.repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace film_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        private readonly IMovieRepository _movieRepository;

        public GenresController(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }
        [HttpGet]
        public async Task<IEnumerable<Movie>> ListGenres()
        {
            return await _movieRepository.Get();
        }
    }
}
