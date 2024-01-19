using DesafioRodonaves.Application.Commads.Request.User;
using DesafioRodonaves.Application.Commads.Response.User;
using DesafioRodonaves.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DesafioRodonaves.MVC.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IUserService _userService;

        public LoginController(IUserService userService)
        {
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost("LoginUser")]
        public async Task<LoginDTOResponse> LoginUser([FromBody] LoginDTORequest request)
        {
            return await _userService.Login(request);
        }
    }
}
