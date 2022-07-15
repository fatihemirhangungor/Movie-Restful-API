# Movie-Restful-API

- ## Net 6 ✔
- ## Entity Framework Core ✔
- ## Web Api ✔
- ## PostgreSQL ✔
- ## Swagger ✔
- ## Redis ✔
- ## Authentication ✔
- ## Background Job Worker ✖

```
git clone https://github.com/fatihemirhangungor/Movie-Restful-API
```

```
cd Movie-Restful-API
```

```
dotnet run
```

# Endpoints

- ## Genres
  - ### ListGenres
    - Lists the all genre types
  - ### AddGenre
    - Add a new genre
  - ### UpdateGenre
    - Update a genre
  - ### DeleteGenre
    - Delete a genre
 
- ## Movies
  - ### GetMovieDetail (:id)
    - Get movie by id
  - ### GetMovieList (:genre-id)
    - Get movie by genre
  - ### GetMovieList (:rate-filter)
    - Get movie by rate
  - ### GetMovieList (:release-date)
    - Get movie by release-date
  - ### Search (:title-rate-year)
    - Get movie by title-rate-year
  - ### AddMovie
    - Add a new movie
  - ### UpdateMovie
    - Update a movie
  - ### DeleteMovie
    - Delete a movie

- ## Trendings
  - ### ListMostViewedMovies
    - Lists the most viewed movies
  - ### ListTopRatedMovies
    - Lists top rated movies

# Details

 - ## Services called via using JWT Token
 - ## Get JWT Token by signing up on swagger once you run the api
 - ## Token will expire if it is not used for 10 minutes

# Schemas

```c#
 MovieDto{
    adult	string
    nullable: true
    belongsToCollection	string
    nullable: true
    budget	string
    nullable: true
    genres	string
    nullable: true
    homepage	string
    nullable: true
    id	integer($int64)
    imdbId	string
    nullable: true
    originalLanguage	string
    nullable: true
    originalTitle	string
    nullable: true
    overview	string
    nullable: true
    popularity	string
    nullable: true
    posterPath	string
    nullable: true
    productionCompanies	string
    nullable: true
    productionCountries	string
    nullable: true
    releaseDate	string
    nullable: true
    revenue	integer($int32)
    nullable: true
    runtime	number($double)
    nullable: true
    spokenLanguages	string
    nullable: true
    status	string
    nullable: true
    tagline	string
    nullable: true
    title	string
    nullable: true
    video	string
    nullable: true
    voteAverage	number($double)
    nullable: true
    voteCount	integer($int32)
    nullable: true
}
```

# Swagger Screenshot
![Swagger](https://github.com/fatihemirhangungor/Movie-Restful-API/blob/main/Images/Swagger.png)
