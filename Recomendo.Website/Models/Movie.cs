using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Recomendo.Website.Models
{
    [Table("Movies")]
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Year { get; set; }
        public int DurationHours { get; set; }
        public int DurationMinutes { get; set; }
        public double Rating { get; set; }
        public string Synopsis { get; set; }
        public string Review { get; set; }
        public IEnumerable<Category> Categories { get; set; }
    }
}
