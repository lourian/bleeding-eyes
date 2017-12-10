using System;
using System.ComponentModel.DataAnnotations;

namespace Cinema.Models
{
    public class MovieShow
    {
        [Required]
        public int Id;

        [Required(ErrorMessage = "Идентификатор фильма не заполнен")]
        [Range(1, int.MaxValue, ErrorMessage = "Идентификатор фильма должен быть больше 0")]
        public int MovieId;

        [Required(ErrorMessage = "Идентификатор кинотеатра не заполнен")]
        [Range(1, int.MaxValue, ErrorMessage = "Идентификатор кинотеатра должен быть больше 0")]
        public int CinemaId;

        [Required(ErrorMessage = "Дата сеанса не заполнена")]
        public DateTime Date;
    }
}
