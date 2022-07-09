using film_api.data.Models;
using film_api.repository;
using Microsoft.AspNetCore.Mvc;
using System.Collections;

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
        public IEnumerable ListGenres()
        {
            return _repositoryWrapper.Genre.ListGenres();
        }
        [HttpPost]
        public void AddGenre(GenreDto genre)
        {
            _repositoryWrapper.Genre.Add(genre);
        }
        [HttpPut]
        public void UpdateGenre(GenreDto genreToUpdate, [FromBody] GenreDto newGenre)
        {
            _repositoryWrapper.Genre.Update(genreToUpdate, newGenre);
        }
        [HttpDelete]
        public void DeleteGenre(GenreDto genre)
        {
            _repositoryWrapper.Genre.Delete(genre);
        }
    }
}
