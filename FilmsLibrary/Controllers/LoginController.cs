using FilmsLibraryBLL.Abstractions.Services;
using FilmsLibraryData.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace FilmsLibrary.Controllers
{
    [ApiController]
    [Route("Login")]
    public class LoginController : ControllerBase
    {
        private readonly IUserService _userService;

        public LoginController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> LoginUser([FromBody] LoginRequest request)
        {
            var token = await _userService.GetTokenAsync(request);

            return Ok(token);
        }
    }
}
