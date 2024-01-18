using DesafioRodonaves.Application.Commads.Request.Unit;
using DesafioRodonaves.Application.Commads.Request.User;
using DesafioRodonaves.Application.Commads.Response.Unit;
using DesafioRodonaves.Application.Commads.Response.User;
using DesafioRodonaves.Application.Interfaces;
using DesafioRodonaves.Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DesafioRodonaves.MVC.Controllers
{
    [Route("api/")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("GetUserById/{id:int}")]
        public async Task<GetUserByIdDTOResponse> GetUserById(int id)
        {
            return await _userService.GetById(id);
        }

        [HttpGet("GetAllUser")]
        public async Task<IEnumerable<GetAllUserDTOResponse>> GetAllUser()
        {
            return await _userService.GetAll();
        }

        [HttpPut("UpdateUser/{id:int}")]
        public async Task<string> UpdateUser([FromBody] UpdateUserDTORequest user, int id)
        {
            return await _userService.Update(user, id);
        }

        [HttpDelete("DeleteUser/{id:int}")]
        public async Task<string> DeleteUser(int id)
        {
            return await _userService.Delete(id);
        }
    }
}
