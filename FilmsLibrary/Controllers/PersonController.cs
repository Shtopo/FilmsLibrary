using FilmsLibraryBLL.Abstractions.Services;
using FilmsLibraryData.DBContext;
using FilmsLibraryData.DTOs;
using FilmsLibraryData.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FilmsLibrary.Controllers
{
    [ApiController]
    [Route("Person")]
    [Authorize]
    public class PersonController : ControllerBase
    {
        private readonly FilmsContext _context;
        private readonly IPersonService _personService;

        public PersonController(FilmsContext context, IPersonService personService)
        {
            _context = context;
            _personService = personService;
        }


        [HttpPut("add")]
        public async Task<IActionResult> AddPerson([FromQuery] string personName)
        {
            var personId = await _personService.CreatePersonAsync(personName);

            return Ok(personId);
        }

        [HttpGet("person")]
        public async Task<IActionResult> ReadPerson([FromQuery] int personID)
        {
            var person = await _personService.ReadPersonAsync(personID);

            return Ok(person);
        }

        [HttpPost("renamePerson")]
        public async Task<IActionResult> RenamePerson([FromQuery] int personID, [FromQuery] string personName)
        {
            var person = await _personService.RenamePersonAsync(personID, personName);
            
            return Ok(person);
        }

        [HttpDelete]
        public async Task<IActionResult> DeletePerson([FromQuery] int personId)
        {

            var person = await _personService.DeletePersonAsync(personId);

            return Ok(person);
        }
    }
}
