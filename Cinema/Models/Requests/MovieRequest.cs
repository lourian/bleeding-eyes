using System.ComponentModel.DataAnnotations;

namespace Cinema.Models.Requests
{
    public class MovieRequest : IRequest
    {
        [Required(ErrorMessage = "Название фильма не заполнено")]
        [StringLength(500, MinimumLength = 5, ErrorMessage = "Название фильма должно быть в пределах от 5 до 500 символов")]
        public string Name { get; set; }

        public string Description { get; set; }
    }
}
