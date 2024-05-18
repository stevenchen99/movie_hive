using MovieHive.Data;
using MovieHive.Models;
using MovieHive.Repositories.Interfaces;

namespace MovieHive.Repositories
{
    public class MovieRepo : Repository<Movie>, IMovieRepo
    {
        /*** Constructor ***/
        public MovieRepo(AppDbContext db)
            : base(db) { }

        /*** Methods ***/
        public void Update(Movie existingMovie, Movie newMovie)
        {
            existingMovie.MovieId = newMovie.MovieId ?? existingMovie.MovieId;
            existingMovie.Title = newMovie.Title ?? existingMovie.Title;
            existingMovie.Description = newMovie.Description ?? existingMovie.Description;
            existingMovie.Genre = newMovie.Genre ?? existingMovie.Genre;
            existingMovie.Director = newMovie.Director ?? existingMovie.Director;
            existingMovie.Year = newMovie.Year ?? existingMovie.Year;
            existingMovie.Duration = newMovie.Duration ?? existingMovie.Duration;
            existingMovie.Rating = newMovie.Rating ?? existingMovie.Rating;
        }
    }
}
