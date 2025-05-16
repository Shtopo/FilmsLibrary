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

        [HttpGet("findFilms")]
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

        [HttpPut("assignDirector")]
        public async Task<IActionResult> AssignDirector([FromQuery] int filmId, [FromQuery] int directorId)
        {
            var success = await _filmService.AssignDirectorAsync(filmId, directorId);
            if (!success)
                return NotFound("Film or director not found");

            return Ok("Director assigned to film.");
        }


        [HttpPost("AddGanre")]
        public async Task<IActionResult> AddFilmGenres([FromQuery] int filmId, [FromQuery] int genreId)
        {               
            var success = await _filmService.AssignGenreAsync(filmId, genreId);
            if (!success)
                return NotFound("Film or genre not found");

            return Ok("Genre assigned to film.");
        }

        [HttpPost("AddCountry")]
        public async Task<IActionResult> AddFilmCountry([FromQuery] int filmId, [FromQuery] int countryId)
        {
            var success = await _filmService.AssignCountryAsync(filmId, countryId);
            if (!success)
                return NotFound("Film or country not found");

            return Ok("Country assigned to film.");
        }

        [HttpPost("AddActors")]
        public async Task<IActionResult> AddFilmActors([FromQuery] int filmId, [FromQuery] int actorId)
        {
            var success = await _filmService.AssignActorsAsync(filmId, actorId);
            if (!success)
                return NotFound("Film or actor not found");

            return Ok("Actor assigned to film.");
        }

    }
}

