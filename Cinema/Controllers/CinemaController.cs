using Cinema.Attributes;
using Cinema.Models.Requests;
using Cinema.Repositories.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Cinema.Controllers
{
    [ValidateModel]
    public class CinemaController : Controller
    {
        private IRepository<Models.Cinema> _cinemaRepository;

        public CinemaController(IRepository<Models.Cinema> cinemaRepository)
        {
            _cinemaRepository = cinemaRepository;
        }

        [HttpGet]
        [Route("/cinema/getall")]
        public async Task<Models.Cinema[]> GetAll()
        {
            return await _cinemaRepository.GetAll();
        }

        [HttpGet]
        [Route("/cinema/{id}/get")]
        public async Task<Models.Cinema[]> GetAll(int id)
        {
            return await _cinemaRepository.GetByFilter(new EntityFilter { EntityId = id });
        }

        [HttpPost]
        [Route("/cinema/add")]
        public async Task Add([FromBody] CinemaRequest request)
        {
            await _cinemaRepository.Add(request);
        }

        [HttpDelete]
        [Route("/cinema/remove")]
        public async Task Remove(int cinemaId)
        {
            await _cinemaRepository.Remove(cinemaId);
        }
    }
}
