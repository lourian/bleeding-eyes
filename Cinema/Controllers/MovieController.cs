using Cinema.Attributes;
using Cinema.Models;
using Cinema.Models.Requests;
using Cinema.Repositories.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Cinema.Controllers
{
    [ValidateModel]
    public class MovieController : Controller
    {
        private IRepository<Movie> _movieRepository;

        public MovieController(IRepository<Movie> movieRepository)
        {
            _movieRepository = movieRepository;
        }

        [HttpGet]
        [Route("/movie/getall")]
        public async Task<Movie[]> GetAll()
        {
            return await _movieRepository.GetAll();
        }

        [HttpGet]
        [Route("/movie/{id}/get")]
        public async Task<Movie[]> Get(int id)
        {
            return await _movieRepository.GetByFilter(new EntityFilter { EntityId = id });
        }

        [HttpPost]
        [Route("/movie/add")]
        public async Task Add([FromBody] MovieRequest request)
        {
            await _movieRepository.Add(request);
        }

        [HttpDelete]
        [Route("/movie/remove")]
        public async Task Remove(int movieId)
        {
            await _movieRepository.Remove(movieId);
        }
    }
}
