using MovieHive.Models;

namespace MovieHive.Repositories.Interfaces
{
    public interface IMovieRepo : IRepository<Movie>
    {
        void Update(Movie existingMovie, Movie newMovie);
    }
}