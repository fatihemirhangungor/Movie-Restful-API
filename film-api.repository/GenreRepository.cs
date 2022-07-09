using film_api.data.Models;
using Newtonsoft.Json;
using System.Collections;

namespace film_api.repository
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
            var genres = dbContext.Movies.Select(x => x.Genres);
            foreach (var item in genres)
            {
                var stuff = JsonConvert.DeserializeObject<List<GenreDto>>(item);
                foreach (var item2 in stuff)
                {
                    GenreDto.genreNames.Add(item2);
                }
            }
            return GenreDto.genreNames;
        }
        public void Add(GenreDto genre)
        {
            GenreDto.genreNames.Add(genre);
        }
        public void Update(GenreDto genreToUpdate, GenreDto newGenre)
        {
            Delete(genreToUpdate);
            Add(newGenre);
        }
        public void Delete(GenreDto genre)
        {
            GenreDto.genreNames.Remove(genre);
        }
    }
}
