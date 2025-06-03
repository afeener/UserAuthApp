using Microsoft.AspNetCore.Mvc;
using UserAuthApp.Application.Services;

namespace UserAuthApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;

        public AuthController(AuthService authService)
        {
            _authService = authService;
        }

        [HttpGet("login")]
        public IActionResult Login(string email, string password)
        {
            var isAuthenticated = _authService.Authenticate(email, password);

            if (!isAuthenticated)
                return Unauthorized("Invalid credentials");

            return Ok("Login successful");
        }
    }
}