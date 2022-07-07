using film_api.data;
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
        private readonly IMovieRepository _movieRepository;

        public MoviesController(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }
        [HttpGet]
        public async Task<IEnumerable<Movie>> GetMovies()
        {
            return await _movieRepository.Get();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Movie>> GetMovieDetail(int id)
        {
            return await _movieRepository.Get(id);
        }
        [HttpPost]
        public async Task<ActionResult<Movie>> AddMovie([FromBody] Movie movie)
        {
            var newMovie = await _movieRepository.Create(movie);
            return CreatedAtAction(nameof(GetMovies),
            new
            {
                id = newMovie.Id,
                title = newMovie.Title,
                release_date = newMovie.Release_Date,
                rate = newMovie.Rate,
                summary = newMovie.Summary,
                actors = newMovie.Actors,
                genres = newMovie.Genres,
            },
            newMovie
            );
        }
        [HttpPut]
        public async Task<ActionResult> UpdateMovie(int id, [FromBody] Movie movie)
        {
            if (id != movie.Id)
            {
                return BadRequest();
            }

            await _movieRepository.Update(movie);

            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteMovie(int id)
        {
            var movieToDelete = await _movieRepository.Get(id);
            if (movieToDelete == null)
            {
                return NotFound();
            }
            await _movieRepository.Delete(movieToDelete.Id);
            return NoContent();
        }
    }
}
