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
    [Route("Users")]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly FilmsContext _context;
        private readonly IUserService _userService;

        public UserController(FilmsContext context, IUserService userService)
        {
            _context = context;
            _userService = userService;
        }

        [HttpPut]
        public async Task<IActionResult> CreateUser([FromQuery] string userName)
        {

            var userId = await _userService.CreateUserAsync(userName);

            return Ok(userId);
        }

        [HttpGet("user")]
        
        public async Task<User> ReadUser([FromQuery] int userID)
        {
            var user = await _userService.ReadUserAsync(userID);

            return user;
        }

        [HttpGet("users")]
        public async Task<List<User>> GetAllUsers()
        {
            var users = await _userService.GetAllUsersAsync();

            return users;
        }

        [HttpPost("rename")]
        public async Task<IActionResult> RenameUser([FromQuery] int userID, [FromQuery] string newName)
        {
            var user = await _userService.RenameUserAsync(userID, newName);

            return Ok(user);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteUser([FromQuery] int userId)
        {

            var user = await _userService.DeleteUserAsync(userId);
            return Ok();
        }
    }
}
