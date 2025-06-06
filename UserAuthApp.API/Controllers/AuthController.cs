using Microsoft.AspNetCore.Mvc;
using UserAuthApp.Application.Services;
using UserAuthApp.Common;

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
                return Unauthorized(Messages.InvalidCredentials);

            return Ok(Messages.LoginSuccessful);
        }

        [HttpPost("changePassword")]
        public IActionResult ChangePassword(string email, string currentPassword, string? newPassword)
        {
            var isChanged = _authService.ChangePassword(email, currentPassword, newPassword);

            if (!isChanged)
                return Unauthorized(Messages.InvalidCredentials);

            return Ok(Messages.PasswordChanged);
        }
    }
}