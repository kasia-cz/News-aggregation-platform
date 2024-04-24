using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NewsPlatform.Application.DTOs.UserDTOs;
using NewsPlatform.Application.Interfaces;

namespace NewsPlatform.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserAppService _userAppService;

        public UserController(IUserAppService userAppService)
        {
            _userAppService = userAppService;
        }

        [HttpPost("register")]
        public async Task<ActionResult> Register(RegisterDTO model)
        {
            await _userAppService.Register(model);
            return NoContent();
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login(LoginDTO model)
        {
            await _userAppService.Login(model);
            return NoContent();
        }

        [HttpPost("logout")]
        [Authorize]
        public async Task<ActionResult> Logout()
        {
            await _userAppService.Logout();
            return NoContent();
        }
    }
}
