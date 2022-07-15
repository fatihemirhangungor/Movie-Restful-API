using film_api.data.Models;
using film_api.repository.BaseRepository.Abstract;
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

        /// <summary>
        /// Lists all the movies
        /// </summary>
        /// <returns>List<MovieDto></returns>
        [HttpGet]
        public IEnumerable<MovieDto> GetMovies()
        {
            return _repositoryWrapper.Movie.Get();
        }

        /// <summary>
        /// Get movie by id
        /// </summary>
        /// <param name="id">Id of the movie</param>
        /// <returns>MovieDto</returns>
        [HttpGet("{id}")]
        public IEnumerable<MovieDto> GetMovieDetail(int id)
        {
            return _repositoryWrapper.Movie.Get(x => x.Id == id);
        }

        /// <summary>
        /// Get movies by genre
        /// </summary>
        /// <param name="genreDto">GenreDto (id, name)</param>
        /// <returns>List<MovieDto></returns>
        [HttpGet("genre")]
        public IEnumerable GetMovieList([FromQuery]GenreDto genreDto)
        {
            return _repositoryWrapper.Movie.GetMovieListByGenre(genreDto);
        }

        /// <summary>
        /// Get movies by rate, VoteAverage on database
        /// </summary>
        /// <param name="rate">Decimal value as in point of a movie</param>
        /// <returns>List<MovieDto></returns>
        [HttpGet("rate")]
        public IEnumerable GetMovieList(decimal rate)
        {
            return _repositoryWrapper.Movie.GetMovieListByRate(rate);
        }

        /// <summary>
        /// Get movies by release-date
        /// </summary>
        /// <param name="date">Release date of a movie, yyyy-mm-dd</param>
        /// <returns></returns>
        [HttpGet("release-date")]
        public IEnumerable GetMovieListByReleaseDate(string date)
        {
            return _repositoryWrapper.Movie.GetMovieListByReleaseDate(date);
        }

        /// <summary>
        /// Get movies by parameters -> title, rate, date
        /// </summary>
        /// <param name="title">Title of movie</param>
        /// <param name="rate">Rate of movie</param>
        /// <param name="date">Date of movie</param>
        /// <returns></returns>
        [HttpGet("title-rate-year")]
        public IEnumerable Search(string title, decimal rate, string date)
        {
            return _repositoryWrapper.Movie.Search(title, rate, date);
        }

        /// <summary>
        /// Create a new movie
        /// </summary>
        /// <param name="movie">Movie Dto</param>
        [HttpPost]
        public void AddMovie([FromBody] MovieDto movie)
        {
            _repositoryWrapper.Movie.Create(movie);
        }

        /// <summary>
        /// Update Movie
        /// </summary>
        /// <param name="movie">Movie Dto</param>
        [HttpPut]
        public void UpdateMovie([FromBody] MovieDto movie)
        {
            _repositoryWrapper.Movie.Update(movie);
        }

        /// <summary>
        /// Delete a movie by id
        /// </summary>
        /// <param name="id">Id of the movie</param>
        [HttpDelete("{id}")]
        public void DeleteMovie(int id)
        {
            var movieToDelete = _repositoryWrapper.Movie.Get(x => x.Id == id).FirstOrDefault();
            _repositoryWrapper.Movie.Delete(movieToDelete);
        }
    }
}
