using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using MovieHive.Data;
using MovieHive.Repositories.Interfaces;

namespace MovieHive.Repositories
{
    public class Repository<T> : IRepository<T>
        where T : class
    {
        /*** Properties ***/
        private readonly AppDbContext _db;
        internal DbSet<T> _dbSet;

        /*** Constructor ***/
        public Repository(AppDbContext db)
        {
            _db = db;
            _dbSet = _db.Set<T>();
        }

        /*** Methods ***/
        public async Task<IEnumerable<T>> GetAll()
        {
            IQueryable<T> data = _dbSet;
            return await data.ToListAsync();
        }

        public async Task<T?> Get(
            Expression<Func<T, bool>> filter,
            List<string>? propsInclude = null
        )
        {
            // IEnumerable is typically used for querying in-memory collections, such as arrays, lists, or collections.
            // IQueryable is used for querying data from external data sources like databases, web services, or other data providers.
            IQueryable<T> data = _dbSet;
            if (propsInclude != null && propsInclude.Count != 0)
            {
                foreach (string prop in propsInclude)
                {
                    /* Eager Loading */
                    data = data.Include(prop);
                }
            }

            return await data.FirstOrDefaultAsync(filter);
        }

        public async Task Add(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public void Remove(T entity)
        {
            _dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            _dbSet.RemoveRange(entities);
        }
    }
}
