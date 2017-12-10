using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Cinema.Models
{
    public class Movie
    {
        [Required]
        public int Id { get; }

        [Required]
        [StringLength(500, MinimumLength = 5, ErrorMessage = "Название фильма должно быть в пределах от 5 до 500 символов")]
        public string Name { get; set; }

        public string Description { get; set; }
    }
}
