using DesafioRodonaves.Application.Commads.Request.Collaborator;
using DesafioRodonaves.Application.Commads.Response.Collaborator;
using DesafioRodonaves.Application.Interfaces;
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

        [HttpGet("GetCollaboratorById/{id:int}")]
        public async Task<GetCollaboratorByIdDTOResponse> GetCollaboratorById(int id)
        {
            return await _collaboratorService.GetById(id);
        }

        [HttpGet("GetAllCollaborator")]
        public async Task<IEnumerable<GetAllCollaboratorDTOResponse>> GetAllCollaborator()
        {
            return await _collaboratorService.GetAll();
        }

        [HttpPost("CreateCollaborator")]
        public async Task<string> CreateCollaborator([FromBody] CreateCollaboratorDTORequest collaborator)
        {
            return await _collaboratorService.Create(collaborator);
        }

        

        [HttpPut("UpdateCollaborator/{id:int}")]
        public async Task<string> UpdateCollaborator([FromBody] UpdateCollaboratorDTORequest collaborator, int id)
        {
            return await _collaboratorService.Update(collaborator, id);
        }

        [HttpDelete("DeleteCollaborator/{id:int}")]
        public async Task<string> DeleteCollaborator(int id)
        {
            return await _collaboratorService.Delete(id);
        }
    }
}
