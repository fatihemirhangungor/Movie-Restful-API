using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace film_api.data.Models
{
    [Table("MOVIE")]
    public partial class MovieDto
    {
        [Column("adult")]
        public string Adult { get; set; } = null!;
        [Column("belongs_to_collection")]
        public string? BelongsToCollection { get; set; }
        [Column("budget")]
        public string Budget { get; set; } = null!;
        [Column("genres")]
        public string Genres { get; set; } = null!;
        [Column("homepage")]
        public string? Homepage { get; set; }
        [Column("id")]
        public long Id { get; set; }
        [Column("imdb_id")]
        public string? ImdbId { get; set; }
        [Column("original_language")]
        public string? OriginalLanguage { get; set; }
        [Column("original_title")]
        public string OriginalTitle { get; set; } = null!;
        [Column("overview")]
        public string? Overview { get; set; }
        [Column("popularity")]
        public string? Popularity { get; set; }
        [Column("poster_path")]
        public string? PosterPath { get; set; }
        [Column("production_companies")]
        public string? ProductionCompanies { get; set; }
        [Column("production_countries")]
        public string? ProductionCountries { get; set; }
        [Column("release_date")]
        public string? ReleaseDate { get; set; }
        [Column("revenue")]
        public int? Revenue { get; set; }
        [Column("runtime")]
        public decimal? Runtime { get; set; }
        [Column("spoken_languages")]
        public string? SpokenLanguages { get; set; }
        [Column("status")]
        public string? Status { get; set; }
        [Column("tagline")]
        public string? Tagline { get; set; }
        [Column("title")]
        public string? Title { get; set; }
        [Column("video")]
        public string? Video { get; set; }
        [Column("vote_average")]
        public decimal? VoteAverage { get; set; }
        [Column("vote_count")]
        public int? VoteCount { get; set; }
    }
}
