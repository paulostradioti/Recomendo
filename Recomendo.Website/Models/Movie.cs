using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Recomendo.Website.Models
{
    [Table("Movies")]
    public class Movie
    {
        public int Id { get; set; }

        [DisplayName("Título do Filme")]
        [Required(ErrorMessage = "O Título do Filme é obrigatório")]
        public string Title { get; set; }

        [DisplayName("Ano de Lançamento")]
        [Required(ErrorMessage = "O Ano de Lançamento é obrigatório")]
        public string Year { get; set; }

        [DisplayName("Horas de Duração")]
        [Required]
        public int DurationHours { get; set; }

        [DisplayName("Minutos de Duração")]
        [Required]
        public int DurationMinutes { get; set; }

        [DisplayName("Nota")]
        [Required]
        public double Rating { get; set; }

        [DisplayName("Opinião")]
        [Required(ErrorMessage = "A Opinião sobre o Filme é obrigatória")]
        public string Review { get; set; }

        [DisplayName("Capa ou Poster do Filme")]
        public string Image { get; set; }

        [DisplayName("Categorias")]
        public IEnumerable<Category> Categories { get; set; }
    }
}
