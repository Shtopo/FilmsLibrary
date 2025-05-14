using FilmsLibraryBLL.Abstractions.Services;
using FilmsLibraryBLL.Services;
using FilmsLibraryData.DBContext;
using FilmsLibraryData.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FilmsLibrary.Controllers
{
    [ApiController]
    [Route("Genre")]
    [Authorize]
    public class GenreController : Controller
    {
        private readonly FilmsContext _context;
        private readonly IGenreService _genreService;

        public GenreController(FilmsContext context, IGenreService genreService)
        {
            _context = context;
            _genreService = genreService;
        }

        [HttpPut("AddGenre")]
        public async Task<IActionResult> AddGenre([FromQuery] string genreName)

        {
            var genreId = await _genreService.AddGenreAsync(genreName);
            return Ok(genreId);
        }

        [HttpGet("genres")]
        public async Task<IActionResult> ReadAllGenres()
        {
            var genres = await _genreService.ReadAllGenresAsync();
            return Ok(genres);
        }

        [HttpPost("renameGenre")]
        public async Task<IActionResult> RenameGenre([FromQuery] int genreID, [FromQuery] string genreName)
        {
            var genre = await _genreService.RenameGenreAsync(genreID, genreName);

            return Ok(genre);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteGenre([FromQuery] int genreId)
        {

            var genre = await _genreService.DeleteGenreAsync(genreId);

            return Ok(genre);
        }
    }
}
