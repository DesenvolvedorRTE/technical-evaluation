
using DesafioRodonaves.Application.DTOS;
using DesafioRodonaves.Application.Interfaces;
using DesafioRodonaves.Domain.Commons.Execptions;
using DesafioRodonaves.Domain.Entities;
using DesafioRodonaves.Domain.Interfaces;
using DesafioRodonaves.Domain.Validations;
using DesafioRodonaves.Infra.Data.Context;
using FluentValidation;
using Mapster;

namespace DesafioRodonaves.Application.Services
{
    public class UnitService : IUnitService
    {
        private readonly IUnitRepository _unitRepository;
        private readonly IUnitOfWork<ApplicationDbContext> _uow;
        private readonly UnitValidation _validations;

        public UnitService(IUnitRepository unitRepository, IUnitOfWork<ApplicationDbContext> uow, UnitValidation validations)
        {
            _unitRepository = unitRepository;
            _uow = uow;
            _validations = validations;
        }

        public async Task<string> Create(UnitDTO entity)
        {
            var unit = entity.Adapt<Unit>();
            var unitValidation = await _validations.ValidateAsync(unit);
            var propertyUnitName = await _unitRepository.PropertyUnitNameExists(unit.UnitName); 
            var propertyUnitCode = await _unitRepository.PropertyUnitNameExists(unit.UnitCode);

            if (!unitValidation.IsValid) 
                throw new ValidationException(unitValidation.Errors);

            if (propertyUnitName != null || propertyUnitCode != null)
                throw new BadRequestException("Já existe uma unidade com estás informações de nome de unidade ou código da unidade");

            _unitRepository.Create(unit);

            await _uow.Commit();

            return $"Id da nova unidade: {unit.Id}";
        }

        public void Delete(UnitDTO entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<UnitDTO>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<UnitDTO> GetById(int id)
        {
            // Busca unit e por id e verifica se ela existe.
            var unitId = await _unitRepository.GetById(id);

            if (unitId is null)
                throw new NotFoundException("Unidade não encontrada");

            return unitId.Adapt<UnitDTO>();
        }

        public void Update(UnitDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}
