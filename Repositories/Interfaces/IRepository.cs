using System.Linq.Expressions;

namespace MovieHive.Repositories.Interfaces
{
    public interface IRepository<T>
        where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T?> Get(Expression<Func<T, bool>> filter, List<string>? propsInclude = null);
        Task Add(T entity);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);
    }
}
