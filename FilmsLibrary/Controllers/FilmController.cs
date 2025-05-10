using FilmsLibraryBLL.Abstractions.Services;
using FilmsLibraryBLL.Services;
using FilmsLibraryData.DBContext;
using FilmsLibraryData.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace FilmsLibrary.Controllers
{
    [ApiController]
    [Route("films")]
    [Authorize]
    public class FilmController : ControllerBase
    {
        private readonly FilmsContext _context;
        private readonly IFilmService _filmService;
        public FilmController(FilmsContext context, IFilmService filmService)
        {
            _context = context;
            _filmService = filmService;
        }

        [HttpPut("putFilm")]
        public async Task<IActionResult> PutFilm([FromQuery] string filmName)
        {
            var filmId = await _filmService.PutFilmAsync(filmName);

            return Ok(filmId);
        }

        [HttpGet("findFilm")]
        public async Task<IActionResult> GetFilms()
        {
            var films = await _filmService.GetFilmsAsync();    

            return Ok(films);
        }

        [HttpPost("renameFilm")]
        public async Task<IActionResult> RenameFilm([FromQuery] string filmName, [FromQuery] string newName)
        {
            if(string.IsNullOrWhiteSpace(filmName) || string.IsNullOrWhiteSpace(newName))
            {
                return BadRequest("Invalid input parameters.");
            }
            var film = await _filmService.RenameFilmAsync(filmName, newName);

            return Ok(film);
        }
    }
}

