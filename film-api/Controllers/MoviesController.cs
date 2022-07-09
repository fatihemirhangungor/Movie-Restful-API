using film_api.data.Models;
using film_api.repository;
using Microsoft.AspNetCore.Mvc;

namespace film_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IRepositoryWrapper _repositoryWrapper;

        public MoviesController(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }
        [HttpGet]
        public IEnumerable<MovieDto> GetMovies()
        {
            return _repositoryWrapper.Movie.Get();
        }
        [HttpGet("{id}")]
        public IEnumerable<MovieDto> GetMovieDetail(int id)
        {
            return _repositoryWrapper.Movie.Get(x => x.Id == id);
        }
        [HttpGet("movies/{genre}")]
        public IEnumerable<MovieDto> GetMovieList(string genre)
        {
            return _repositoryWrapper.Movie.Get(x => x.Genres == genre);
        }
        [HttpPost]
        public void AddMovie([FromBody] MovieDto movie)
        {
            _repositoryWrapper.Movie.Create(movie);
        }
        [HttpPut]
        public void UpdateMovie([FromBody] MovieDto movie)
        {
            _repositoryWrapper.Movie.Update(movie);
        }
        [HttpDelete("{id}")]
        public void DeleteMovie(int id)
        {
            var movieToDelete = _repositoryWrapper.Movie.Get(x => x.Id == id).FirstOrDefault();
            _repositoryWrapper.Movie.Delete(movieToDelete);
        }
    }
}
