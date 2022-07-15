using film_api.repository.BaseRepository.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections;

namespace film_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TrendingsController : ControllerBase
    {
        private readonly IRepositoryWrapper _repositoryWrapper;

        public TrendingsController(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        /// <summary>
        /// Lists top-10 most viewed movies
        /// </summary>
        /// <returns>List<MovieDto></returns>
        [HttpGet("top-10-mostViewed")]
        public IEnumerable ListMostViewedMovies()
        {
            return _repositoryWrapper.Trendings.ListMostViewedMovies();
        }

        /// <summary>
        /// Lists top-rated movies
        /// </summary>
        /// <returns>List<MovieDto></returns>
        [HttpGet("top-10-mostRated")]
        public IEnumerable ListTopRatedMovies()
        {
            return _repositoryWrapper.Trendings.ListTopRatedMovies();
        }
    }
}
