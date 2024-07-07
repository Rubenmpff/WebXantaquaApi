using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebKrpcApi.Services.Mapping.Dtos;
using WebKrpcApi.Services.Services.Interfaces;

namespace WebKrpcApi.Controllers
{
    [Route("WebKrpcApi/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthenticationService _authService;

        public AuthController(IAuthenticationService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            var result = await _authService.RegisterAsync(registerDto);
            if (result.IsSuccess)
            {
                return Ok(new { Token = result.Token });
            }
            else
            {
                return BadRequest(new { Message = result.Message, Errors = result.Errors });
            }
        }

        [HttpPost("login")]
        public async Task<ActionResult<AuthenticationResultDto>> Login([FromBody] LoginDto loginDto)
        {
            var result = await _authService.LoginAsync(loginDto);
            if (result.IsSuccess)
            {
                return Ok(new { Token = result.Token });
            }
            return Unauthorized(new { Message = result.Message, Errors = result.Errors });
        }
    }
}