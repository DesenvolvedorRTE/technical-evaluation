using DesafioRodonaves.Application.Commads.Request.Unit;
using DesafioRodonaves.Application.Commads.Response.Unit;
using DesafioRodonaves.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DesafioRodonaves.MVC.Controllers
{
    [Route("api/")]
    [ApiController]
    public class UnitController : ControllerBase
    {
        private readonly IUnitService _unitService;

        public UnitController(IUnitService unitService)
        {
            _unitService = unitService;
        }

        [Authorize(Roles = "commonCollaborator, collaboratorAdministrator")]
        [HttpGet("GetUnitById/{id:int}")]
        public async Task<GetUnitByIdDTOResponse> GetUnitById(int id)
        {
            return await _unitService.GetById(id);
        }

        [Authorize(Roles = "commonCollaborator, collaboratorAdministrator")]
        [HttpGet("GetAllUnit")]
        public async Task<IEnumerable<GetAllUnitDTOResponse>> GetAllUnit()
        {
            return await _unitService.GetAll();
        }

        [Authorize(Roles = "commonCollaborator, collaboratorAdministrator")]
        [HttpGet("GetAllUnitAndAllCollaboratorAssociate")]
        public async Task<IEnumerable<GetAllUnitAndAllCollaboratorDTOResponse>> GetAllUnitAndAllCollaboratorAssociate()
        {
            return await _unitService.GetAllUnitAndAllCollaboratorAssociate();
        }

        [Authorize(Roles = "collaboratorAdministrator")]
        [HttpPost("CreateUnit")]
        public async Task<string> CreateUnit([FromBody] CreateUnitDTORequest unit)
        {
            return await _unitService.Create(unit);
        }

        [Authorize(Roles = "collaboratorAdministrator")]
        [HttpPut("UpdateUnit/{id:int}")]
        public async Task<string> UpdateUnit([FromBody] UpdateUnitDtoRequest unit, int id)
        {
            return await _unitService.Update(unit, id);
        }

        [Authorize(Roles = "collaboratorAdministrator")]
        [HttpDelete("DeleteUnit/{id:int}")]
        public async Task<string> DeleteUnit(int id)
        {
            return await _unitService.Delete(id);
        }
    }
}