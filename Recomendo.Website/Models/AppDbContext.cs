using Microsoft.EntityFrameworkCore;

namespace Recomendo.Website.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        
        public DbSet<Movie> Movies { get; set; }
        
        public DbSet<Category> Categories { get; set; }
    }
}
