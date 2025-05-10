using FilmsLibraryBLL.Abstractions.Services;
using FilmsLibraryData.DBContext;
using FilmsLibraryData.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FilmsLibrary.Controllers
{
    [ApiController]
    [Route("Сountry")]
    [Authorize]
    public class CountryController : ControllerBase
    {
        private readonly FilmsContext _context;
        private readonly ICountryService _countryService;

        public CountryController(FilmsContext context, ICountryService countryService)
        {
            _context = context;
            _countryService = countryService;
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddCountry([FromQuery] string countryName)
        {
            var countryId = await _countryService.AddCountryAsync(countryName);

            return Ok(countryId);
        }

        [HttpGet("country")]
        public async Task<IActionResult> ReadCountry([FromQuery] int countryID)
        {
            var country = await _countryService.ReadCountryAsync(countryID);

            return Ok(country);
        }

        [HttpGet("countries")]
        public async Task<List<Country>> ReturnCountry()
        {
            var country = await _countryService.ReturnCountryAsync();

            return country;
        }

        [HttpPost("renameCountry")]
        public async Task<IActionResult> RenameCountry([FromQuery] int countryID, [FromQuery] string countryName)
        {
            var country = await _countryService.RenameCountryAsync(countryID, countryName);

            return Ok(country);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCountry([FromQuery] int countryId)
        {

            var country = await _countryService.DeleteCountryAsync(countryId);

            return Ok(country);
        }
    }

}
