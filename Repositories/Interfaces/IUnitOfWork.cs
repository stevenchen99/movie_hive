namespace MovieHive.Repositories.Interfaces
{
    public interface IUnitOfWork
    {
        /*** Repositories(Properties) ***/
        IMovieRepo repoMovie { get; }

        /*** Methods ***/
        Task Save();
    }
}
