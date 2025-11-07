using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Endpoint.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly TokenService _tokenService;
        public AuthController(TokenService tokenService)
        {
            _tokenService = tokenService;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] User login)
        {
            if (login.Username == "admin" && login.PasswordHash == "1234")
            {
                var token = _tokenService.GenerateToken(new User { Username = "admin", Role = "Admin" });
                return Ok(new { token });
            }
            return Unauthorized();
        }
    }
}
