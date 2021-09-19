using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recomendo.Website.Models
{
    public interface IRepository
    {
        IQueryable<Movie> Movies { get; }
        IQueryable<Category> Categories { get; }

        void Add(Category category);
    }
}
