using MovieHive.Data;
using MovieHive.Repositories.Interfaces;

namespace MovieHive.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        /*** Properties ***/
        private readonly AppDbContext _db;

        /*** Repositories(Properties) ***/
        public IMovieRepo repoMovie { get; private set; }

        /*** Constructor ***/
        public UnitOfWork(AppDbContext db)
        {
            _db = db;
            repoMovie = new MovieRepo(_db);
        }

        /*** Methods ***/
        public async Task Save()
        {
            await _db.SaveChangesAsync();
        }
    }
}
