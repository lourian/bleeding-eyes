using System;
using System.ComponentModel.DataAnnotations;

namespace Cinema.Repositories.Filters
{
    public class MovieShowFilter : IFilter
    {
        public MovieShowFilter(int cinemaId, int movieId, DateTime date)
        {
            CinemaId = cinemaId;
            MovieId = movieId;
            Date = date;
        }

        public int EntityId { get; set; }

        [Required(ErrorMessage = "Идентификатор кинотеатра не заполнен")]
        [Range(1, int.MaxValue, ErrorMessage = "Идентификатор кинотеатра должен быть больше 0")]
        public int CinemaId { get; set; }

        [Required(ErrorMessage = "Идентификатор фильма не заполнен")]
        [Range(1, int.MaxValue, ErrorMessage = "Идентификатор фильма должен быть больше 0")]
        public int MovieId { get; set; }

        [Required(ErrorMessage = "Дата сеанса не заполнена")]
        public DateTime Date { get; set; }
    }
}
