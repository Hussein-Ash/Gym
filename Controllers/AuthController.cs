using EvaluationBackend.DATA.DTOs.User;
using EvaluationBackend.Services;
using EvaluationBackend.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OneSignalApi.Model;

namespace EvaluationBackend.Controllers
{
    public class AuthController : BaseController
    {
        private readonly IUserService _userService;
        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("Login")]
        public async Task<ActionResult> Login(LoginForm loginForm) => Ok(await _userService.Login(loginForm));

        [HttpPost("Register")]
        public async Task<ActionResult> Register(RegisterForm registerForm) => Ok(await _userService.Register(registerForm));

        // [Authorize]
        // [HttpGet("AccessToken")]
        // public async Task<ActionResult> GetAccessToken() => Ok(await _userService.GetAccessToken(Id, TokenExpier));

    }
}