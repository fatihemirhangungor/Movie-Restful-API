namespace film_api.data.Models
{
    public class GenreDto
    {
        public int Id { get; set; }
        public string ?Name { get; set; }
        public static HashSet<GenreDto>? genreNames = new HashSet<GenreDto>();
    }
}
