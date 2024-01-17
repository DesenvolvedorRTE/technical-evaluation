using DesafioRodonaves.Application.Commads.Request.Unit;
using DesafioRodonaves.Application.Commads.Response.Unit;
using DesafioRodonaves.Application.Interfaces;
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

        [HttpGet("GetUnitById/{id:int}")]
        public async Task<GetUnitByIdDTOResponse> GetUnitById(int id)
        {
            return await _unitService.GetById(id);
        }

        [HttpGet("GetAllUnit")]
        public async Task<IEnumerable<GetAllUnitDTOResponse>> GetAllUnit()
        {
            return await _unitService.GetAll();
        }

        [HttpPost("CreateUnit")]
        public async Task<string> CreateUnit([FromBody] CreateUnitDTORequest unit)
        {
            return await _unitService.Create(unit);
        }

        [HttpPut("UpdateUnit/{id:int}")]
        public async Task<string> UpdateUnit([FromBody] UpdateUnitDtoRequest unit, int id)
        {
            return await _unitService.Update(unit, id);
        }

        [HttpDelete("DeleteUnit/{id:int}")]
        public async Task<string> DeleteUnit(int id)
        {
            return await _unitService.Delete(id);
        }
    }
}
