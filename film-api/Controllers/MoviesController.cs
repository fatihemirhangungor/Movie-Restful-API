using film_api.data.Models;
using film_api.repository.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections;

namespace film_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
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
        [HttpGet("genre")]
        public IEnumerable GetMovieList([FromQuery]GenreDto genreDto)
        {
            return _repositoryWrapper.Movie.GetMovieListByGenre(genreDto);
        }
        [HttpGet("rate")]
        public IEnumerable GetMovieList(decimal rate)
        {
            return _repositoryWrapper.Movie.GetMovieListByRate(rate);
        }
        [HttpGet("release-date")]
        public IEnumerable GetMovieListByReleaseDate(string date)
        {
            return _repositoryWrapper.Movie.GetMovieListByReleaseDate(date);
        }
        [HttpGet("title-rate-year")]
        public IEnumerable Search(string title, decimal rate, string date)
        {
            return _repositoryWrapper.Movie.Search(title, rate, date);
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
