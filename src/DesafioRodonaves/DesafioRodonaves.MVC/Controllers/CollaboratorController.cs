using DesafioRodonaves.Application.Commads.Request.Collaborator;
using DesafioRodonaves.Application.Commads.Request.Unit;
using DesafioRodonaves.Application.Commads.Request.User;
using DesafioRodonaves.Application.Interfaces;
using DesafioRodonaves.Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DesafioRodonaves.MVC.Controllers
{
    [Route("api/")]
    [ApiController]
    public class CollaboratorController : ControllerBase
    {
        private readonly ICollaboratorService _collaboratorService;

        public CollaboratorController(ICollaboratorService collaboratorService)
        {
            _collaboratorService = collaboratorService;
        }

        [HttpPost("CreateCollaborator")]
        public async Task<string> CreateCollaborator([FromBody] CreateCollaboratorDTORequest unit)
        {
            return await _collaboratorService.Create(unit);
        }
    }
}
