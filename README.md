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
    
    belongsToCollection	string
    
    budget	string
    
    genres	string
    
    homepage	string
    
    id	integer($int64)

    imdbId	string
    
    originalLanguage	string
    
    originalTitle	string
    
    overview	string
    
    popularity	string
    
    posterPath	string
    
    productionCompanies	string
    
    productionCountries	string
    
    releaseDate	string
    
    revenue	integer($int32)
    
    runtime	number($double)
    
    spokenLanguages	string
    
    status	string
    
    tagline	string
    
    title	string
    
    video	string
    
    voteAverage	number($double)
    
    voteCount	integer($int32)
    
}
```

# Swagger Screenshot
![Swagger](https://github.com/fatihemirhangungor/Movie-Restful-API/blob/main/Images/Swagger.png)

# Warnings

## - Be aware that app uses port = 5433 for postgresql - you might need to change that to 5432 since its the standard.

## - Run your redis with port specified or you might get StackExchangeException error.

## - Some method's results are too big, therefore some methods returns limited number of entities. Because swagger crashes since dataset is very big for this application.