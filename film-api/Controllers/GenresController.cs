using film_api.data.Models;
using film_api.repository;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace film_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        private readonly IRepositoryWrapper _repositoryWrapper;

        public GenresController(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        [HttpGet]
        public IEnumerable<string> ListGenres()
        {
            return _repositoryWrapper.Movie.ListGenres();
        }
    }
}
