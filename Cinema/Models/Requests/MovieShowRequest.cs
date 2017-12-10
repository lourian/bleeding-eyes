using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Cinema.Models.Requests
{
    public class MovieShowRequest : IRequest
    {
        [Required(ErrorMessage = "Идентификатор кинотеатра не заполнен")]
        public int CinemaId { get; set; }

        [Required(ErrorMessage = "Идентификатор фильма не заполнен")]
        public int MovieId { get; set; }

        [Required(ErrorMessage = "Время сеанса не заполнено")]
        public DateTime Date { get; set; }
    }
}
