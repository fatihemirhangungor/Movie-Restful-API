using film_api.data.Models;
using film_api.repository.Abstract;
using film_api.repository.BaseRepository.Concrete;
using Newtonsoft.Json;
using System.Collections;

namespace film_api.repository.Concrete
{
    public class GenreRepository : RepositoryBase<GenreDto>, IGenreRepository
    {
        private readonly DatabaseContext dbContext;

        public GenreRepository(DatabaseContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        /// <summary>
        /// Get all genres from movie dataset
        /// Basically, the method reads every entiti's genre column, Deserialize it and read name of the genre and add it
        /// to hashset. HashSet used here because no repetitive data wanted
        /// </summary>
        /// <returns>List<string> genres</returns>
        public IEnumerable ListGenres()
        {
            var listOfGenreLists = dbContext.Movies.Select(x => x.Genres).ToList();
            foreach (var genreList in listOfGenreLists)
            {
                var genres = JsonConvert.DeserializeObject<List<GenreDto>>(genreList);
                foreach (var genre in genres)
                {
                    GenreDto.genres.Add(genre.Name);
                }
            }
            return GenreDto.genres;
        }

        /// <summary>
        /// Add a new genre
        /// </summary>
        /// <param name="genre">Name of the genre</param>
        public void Add(string genre)
        {
            GenreDto.genres.Add(genre);
        }

        /// <summary>
        /// Update genre
        /// </summary>
        /// <param name="genreToUpdate">Genre name you want to update</param>
        /// <param name="newGenre">New name of the genre</param>
        public void Update(string genreToUpdate, string newGenre)
        {
            Delete(genreToUpdate);
            Add(newGenre);
        }

        /// <summary>
        /// Delete genre
        /// </summary>
        /// <param name="genre">Name of the genre you want to delete</param>
        public void Delete(string genre)
        {
            GenreDto.genres.Remove(genre);
        }
    }
}
