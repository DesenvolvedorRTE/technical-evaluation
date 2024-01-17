using DesafioRodonaves.Application.DTOS;
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
        public async Task<UnitDTO> GetUnitById(int id)
        {
            return await _unitService.GetById(id);
        }

        [HttpPost("CreateUnit")]
        public async Task<string> CreateUnit(UnitDTO unit)
        {
            return await _unitService.Create(unit);
        }
    }
}
