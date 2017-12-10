using Cinema.Attributes;
using Cinema.Models;
using Cinema.Models.Requests;
using Cinema.Repositories.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Cinema.Controllers
{
    [ValidateModel]
    public class MovieShowController : Controller
    {
        private IRepository<MovieShow> _movieShowRepository;

        public MovieShowController(IRepository<MovieShow> movieShowRepository)
        {
            _movieShowRepository = movieShowRepository;
        }

        [HttpGet]
        [Route("/movieshow/getall")]
        public async Task<MovieShow[]> GetAll()
        {
            return await _movieShowRepository.GetAll();
        }

        [HttpPost]
        [Route("/movieshow/add")]
        public async Task Add([FromBody] MovieShowRequest request)
        {
            await _movieShowRepository.Add(request);
        }

        [HttpPost]
        [Route("/movieshow/getbyfilter")]
        public async Task<MovieShow[]> GetByFilter([FromBody] MovieShowFilter filter)
        {
            return await _movieShowRepository.GetByFilter(filter);
        }

        [HttpPost]
        [Route("/movieshow/getbydate")]
        public async Task<MovieShow[]> GetByDate([FromBody] DateFilter filter)
        {
            return await _movieShowRepository.GetByFilter(filter);
        }

        [HttpDelete]
        [Route("/movieshow/remove")]
        public async Task Remove(int movieShowId)
        {
            await _movieShowRepository.Remove(movieShowId);
        }
    }
}
