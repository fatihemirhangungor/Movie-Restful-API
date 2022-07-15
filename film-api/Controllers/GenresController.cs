using film_api.repository.BaseRepository.Abstract;
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

        /// <summary>
        /// Lists all the genre types
        /// </summary>
        /// <returns>List<GenreDto></returns>
        [HttpGet]
        public IEnumerable ListGenres()
        {
            return _repositoryWrapper.Genre.ListGenres();
        }

        /// <summary>
        /// Create a new genre into HashSet<string> genres in GenreDto model
        /// </summary>
        /// <param name="genre">string value for the name of genre</param>
        [HttpPost]
        public void AddGenre(string genre)
        {
            _repositoryWrapper.Genre.Add(genre);
        }

        /// <summary>
        /// Updates a genre from HashSet<string> genres in GenreDto model
        /// </summary>
        /// <param name="genreToUpdate">Name of the genre that you want to update</param>
        /// <param name="newGenre">New name of the genre</param>
        [HttpPut]
        public void UpdateGenre(string genreToUpdate, string newGenre)
        {
            _repositoryWrapper.Genre.Update(genreToUpdate, newGenre);
        }

        /// <summary>
        /// Deletes a genre from HashSet<string> genres in GenreDto model
        /// </summary>
        /// <param name="genre">Name of the genre that you want to delete</param>
        [HttpDelete]
        public void DeleteGenre(string genre)
        {
            _repositoryWrapper.Genre.Delete(genre);
        }
    }
}
