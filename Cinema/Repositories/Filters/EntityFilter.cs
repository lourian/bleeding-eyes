using System.ComponentModel.DataAnnotations;

namespace Cinema.Repositories.Filters
{
    public class EntityFilter : IFilter
    {
        [Required(ErrorMessage = "Идентификатор сущности должен быть больше 0")]
        public int EntityId { get; set; }
    }
}
