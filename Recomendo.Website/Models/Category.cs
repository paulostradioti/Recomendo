using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Recomendo.Website.Models
{
    [Table("Categories")]
    public class Category
    {
        public int Id { get; set; }

        [DisplayName("Nome da Categoria")]
        public string CategoryName { get; set; }
        public IEnumerable<Movie> Movies { get; set; }
    }
}
