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

        public IEnumerable ListGenres()
        {
            var listOfGenreLists = dbContext.Movies.Select(x => x.Genres);
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
        public void Add(string genre)
        {
            GenreDto.genres.Add(genre);
        }
        public void Update(string genreToUpdate, string newGenre)
        {
            Delete(genreToUpdate);
            Add(newGenre);
        }
        public void Delete(string genre)
        {
            GenreDto.genres.Remove(genre);
        }
    }
}
