using System.Linq;

namespace Recomendo.Website.Models
{
    public class Repository : IRepository
    {
        private readonly AppDbContext context;
        public Repository(AppDbContext context)
        {
            this.context = context;
        }

        public IQueryable<Movie> Movies => context.Movies;

        public IQueryable<Category> Categories => context.Categories;

        public void Add(Category category)
        {
            context.Categories.Add(category);
            context.SaveChanges();
        }
    }
}
