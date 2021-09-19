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

        public void Add(Movie movie)
        {
            context.Movies.Add(movie);
            context.SaveChanges();
        }

        public void Delete(Category category)
        {
            context.Categories.Remove(category);
            context.SaveChanges();
        }

        public void Delete(Movie movie)
        {
            context.Movies.Remove(movie);
            context.SaveChanges();
        }

        public void Update(Category category)
        {
            context.Categories.Update(category);
            context.SaveChanges();
        }

        public void Update(Movie movie)
        {
            context.Movies.Update(movie);
            context.SaveChanges();
        }
    }
}
