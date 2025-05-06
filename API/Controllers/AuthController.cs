using API.DTOs.AuthDto;
using API.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{

    public class AuthController : BaseController
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService){
            _authService = authService;

        }
    
        [HttpPost("register")]
        public async Task<ActionResult> Register(RegisterDto registerDto)
        {
            var response = await _authService.Register(registerDto);
            return StatusCode(response.StatusCode, response);

        }
        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<ActionResult> Login(LoginDto loginDto)
        {
            var response = await _authService.login(loginDto);
            return StatusCode(response.StatusCode, response);
        }
        //
        //have to logout  method
        

    }
}
