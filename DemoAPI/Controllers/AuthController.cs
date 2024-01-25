using DemoAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace DemoAPI.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class AuthController : ControllerBase
    {
        private readonly UserService _userService;
        private readonly JwtService _tokenService;

        public AuthController(UserService userService, JwtService tokenService)
        {
            _userService = userService;
            _tokenService = tokenService;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] User user)
        {
            var authenticatedUser = _userService.Authenticate(user.Username, user.Password);

            if (authenticatedUser == null)
            {
                return Unauthorized(new { message = "Invalid credentials" });
            }

            var token = _tokenService.GenerateToken(authenticatedUser.Username);

            return Ok(new { token });
        }
    }
}
