using System.ComponentModel.DataAnnotations;

namespace Cinema.Models.Requests
{
    public class CinemaRequest : IRequest
    {
        [Required(ErrorMessage = "Название кинотеатра не заполнено")]
        [StringLength(500, MinimumLength = 5, ErrorMessage = "Название кинотеатра должно быть в пределах от 5 до 500 символов")]
        public string Name { get; set; }
    }
}
