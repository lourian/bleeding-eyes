using Cinema.Models.Requests;
using Cinema.Repositories.Filters;
using System.Threading.Tasks;

namespace Cinema
{
    public interface IRepository<T> 
    {
        Task<T[]> GetAll();

        Task<T[]> GetByFilter(IFilter filter);

        Task Add(IRequest request);

        Task Remove(int entityId);
    }
}
