using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using wejdenNefzi.Server.Models;
using wejdenNefzi.Server.Service;

namespace wejdenNefzi.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthentificationController : ControllerBase
    {
        private readonly IAuthentificationService _authService;

        public AuthentificationController(IAuthentificationService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginModel model)
        {
            var token = _authService.Authenticate(model.Email, model.Password);
            if (token == null)
            {
                return Unauthorized();
            }
            return Ok(new { Token = token });
        }
    }
}
    
