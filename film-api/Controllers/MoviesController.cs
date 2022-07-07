using film_api.data.Models;
using film_api.repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        [HttpPost]
        public void AddMovie([FromBody] MovieDto movie)
        {
            _repositoryWrapper.Movie.Create(movie);
            //var newMovie = await _repositoryWrapper.Create(movie);
            //return CreatedAtAction(nameof(GetMovies),
            //new
            //{
            //    id = newMovie.Id,
            //    title = newMovie.Title,
            //    release_date = newMovie.Release_Date,
            //    rate = newMovie.Rate,
            //    summary = newMovie.Summary,
            //    actors = newMovie.Actors,
            //    genres = newMovie.Genres,
            //},
            //newMovie
            //);
        }
        [HttpPut]
        public void UpdateMovie([FromBody] MovieDto movie)
        {
            _repositoryWrapper.Movie.Update(movie);
            //if (id != movie.Id)
            //{
            //    return BadRequest();
            //}

            //await _repositoryWrapper.Update(movie);

            //return NoContent();
        }
        [HttpDelete("{id}")]
        public void DeleteMovie(int id)
        {
            var movieToDelete = _repositoryWrapper.Movie.Get(x => x.Id == id).FirstOrDefault();
            _repositoryWrapper.Movie.Delete(movieToDelete);
            //var movieToDelete = await _repositoryWrapper.Get(id);
            //if (movieToDelete == null)
            //{
            //    return NotFound();
            //}
            //await _repositoryWrapper.Delete(movieToDelete.Id);
            //return NoContent();
        }
    }
}
