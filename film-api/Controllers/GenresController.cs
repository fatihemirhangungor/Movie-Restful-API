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
    public class GenresController : ControllerBase
    {
        private readonly IRepositoryWrapper _repositoryWrapper;

        public GenresController(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        [HttpGet]
        public IEnumerable ListGenres()
        {
            return _repositoryWrapper.Genre.ListGenres();
        }
        [HttpPost]
        public void AddGenre(string genre)
        {
            _repositoryWrapper.Genre.Add(genre);
        }
        [HttpPut]
        public void UpdateGenre(string genreToUpdate, string newGenre)
        {
            _repositoryWrapper.Genre.Update(genreToUpdate, newGenre);
        }
        [HttpDelete]
        public void DeleteGenre(string genre)
        {
            _repositoryWrapper.Genre.Delete(genre);
        }
    }
}
