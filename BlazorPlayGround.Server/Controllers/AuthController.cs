using BlazorPlayGround.Server.Services.AuthServices;
using BlazorPlayGround.Shared.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace BlazorPlayGround.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public static UserLogin user = new UserLogin();
        private readonly IConfiguration _configuration;
        private readonly IAuthService _authService;

        public AuthController(IConfiguration configuration, IAuthService authService)
        {
            _configuration = configuration;
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserLogin>> Register(UserLoginDto request)
        {
           var result = await _authService.Register(request);
            return Ok(result);
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserLogin>> Login(LoginDTo request)
        {
            var result = await _authService.Login(request);
            if (result == "No User Found" || result == "Wrong password.")
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<List<UserLogin>>> GetAllUser()
        {
            var result = await _authService.GetAllUser();
            return Ok(result);
        }
    }
}
