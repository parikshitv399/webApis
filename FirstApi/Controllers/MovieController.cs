using FirstApi.Models;
using FirstApi.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FirstApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieRepository _movieDb;
        public MovieController(IMovieRepository pRepo)
        {
            _movieDb = pRepo;
        }
        [HttpGet("/movies/all")]
        public IActionResult GetAllMovies()
        {
            return Ok(_movieDb.GetAll());
        }
        [HttpPost("/movie/new")]
        public IActionResult AddNew([FromBody] Movie pMovie)
        {
            try
            {
                int pId = _movieDb.AddNew(pMovie);
                return Created($"Created movie with ID {pId}", pMovie);
            }
            catch
            {
                return BadRequest(ModelState);
            }
        }
        [HttpPut("/movie/update/{pId}")]
        public IActionResult UpdateMovie([FromRoute] int pId, [FromBody] Movie updatedMovie)
        {
            try
            {
                _movieDb.UpdateMovie(pId, updatedMovie);
                return Accepted($"Update was successful for ID {pId}!");
            }
            catch (Exception)
            {
                return BadRequest(ModelState);
            }
        }
        [HttpDelete("/movie/delete/{pId}")]
        public IActionResult DeleteMovie([FromRoute] int pId)
        {
            _movieDb.Delete(pId);
            return Accepted($"Movie with ID {pId} was successfully deleted");
        }
        [HttpGet("/movie/find/{pId}")]
        public IActionResult FindMovie([FromRoute] int pId)
        {
            Movie foundMovie = _movieDb.GetSingleMovie(pId);
            return Ok(foundMovie);
        }
    }
}
