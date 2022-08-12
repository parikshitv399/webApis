using FirstApi.Data;
using FirstApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FirstApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesDbController : ControllerBase
    {
        private readonly FirstApiContext _dbContext;
        public MoviesDbController(FirstApiContext context)
        {
            _dbContext = context;
        }
        [HttpGet("/db/movies/all")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _dbContext.Movies.ToListAsync());
        }
        [HttpPost("/db/movies/add")]
        public async Task<IActionResult> AddNew([FromBody] Movie pMovie)
        {
            try
            {
                await _dbContext.Movies.AddAsync(pMovie);
                await _dbContext.SaveChangesAsync();
                return Created("Created Movie! ", pMovie);
            }
            catch (Exception)
            {
                return BadRequest(ModelState);
            }
        }
        [HttpPut("/db/movies/update")]
        public async Task<IActionResult> UpdateMov([FromRoute] int pId, [FromBody] Movie updatedInfo)
        {
            try
            {
                Movie foundMovie = _dbContext.Movies.Find(pId);
                foundMovie.Director = updatedInfo.Director;
                foundMovie.Budget = updatedInfo.Budget;
                foundMovie.Producer = updatedInfo.Producer;
                foundMovie.Cast = updatedInfo.Cast;
                foundMovie.Name = updatedInfo.Name;
                //Update the db
                await _dbContext.SaveChangesAsync();
                return Accepted();
            }
            catch (Exception)
            {
                return BadRequest(ModelState);
            }
        }
        [HttpDelete("/db/movies/delete")]
        public async Task<IActionResult> DelMov([FromRoute] int pId)
        {
            Movie foundMovie = _dbContext.Movies.Find(pId);
            _dbContext.Movies.Remove(foundMovie);
            await _dbContext.SaveChangesAsync();
            return Accepted("Movie deleted!");
        }
    }
}
