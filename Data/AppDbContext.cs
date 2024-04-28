using Microsoft.EntityFrameworkCore;
using MovieHive.Models;

namespace MovieHive.Data{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Movie> Movies { get; set; }
    }

}
