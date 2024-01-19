using DesafioRodonaves.Application.Commads.Request.User;
using DesafioRodonaves.Application.Commads.Response.User;
using DesafioRodonaves.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DesafioRodonaves.MVC.Controllers
{
    [Authorize]
    [Route("api/")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [Authorize(Roles = "commonCollaborator, collaboratorAdministrator")]
        [HttpGet("GetUserById/{id:int}")]
        public async Task<GetUserByIdDTOResponse> GetUserById(int id)
        {
            return await _userService.GetById(id);
        }

        [Authorize(Roles = "commonCollaborator, collaboratorAdministrator")]
        [HttpGet("GetAllUser")]
        public async Task<IEnumerable<GetAllUserDTOResponse>> GetAllUser()
        {
            return await _userService.GetAll();
        }

        [Authorize(Roles = "commonCollaborator, collaboratorAdministrator")]
        [HttpPut("UpdateUser/{id:int}")]
        public async Task<string> UpdateUser([FromBody] UpdateUserDTORequest user, int id)
        {
            return await _userService.Update(user, id);
        }

        [Authorize(Roles = "collaboratorAdministrator")]
        [HttpGet("GetAllUserByStatus/{status:bool}")]
        public async Task<IEnumerable<GetAllUserByStatusDTOResponse>> GetAllUserByStatus(bool status)
        {
            return await _userService.GetAllUserByStatus(status);
        }

    }
}
