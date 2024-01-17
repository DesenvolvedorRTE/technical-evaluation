﻿using DesafioRodonaves.Application.Commads.Request.Unit;
using DesafioRodonaves.Application.Commads.Response.Unit;
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

        public async Task<string> Create(CreateUnitDTORequest entity)
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

        public async Task<string> Delete(int id)
        {
            var unitId = await _unitRepository.GetById(id);

            if (unitId is null)
                throw new NotFoundException($"Unidade com id ({id}), não encontrada");

            _unitRepository.Delete(unitId);
            await _uow.Commit();

            return $"Unidade com id ({id}), foi excluida com sucesso!";
            
        }

        public async Task<IEnumerable<GetAllUnitDTOResponse>> GetAll()
        {
           var unitResponse =  await _unitRepository.GetAll();

            return unitResponse.Adapt<IEnumerable<GetAllUnitDTOResponse>>();
        }

        public async Task<GetUnitByIdDTOResponse> GetById(int id)
        {
            // Busca unit e por id e verifica se ela existe.
            var unitId = await _unitRepository.GetById(id);

            if (unitId is null)
                throw new NotFoundException($"Unidade com id ({id}), não foi encontrada");

            return unitId.Adapt<GetUnitByIdDTOResponse>();
        }

        public async Task<string> Update(UpdateUnitDtoRequest entity, int id)
        {
            var unitId = await _unitRepository.GetById(id);
      
            var propertyUnitName = await _unitRepository.PropertyUnitNameExists(entity.UnitName);
            var propertyUnitCode = await _unitRepository.PropertyUnitNameExists(entity.UnitCode);

            if (unitId is null)
                throw new NotFoundException($"Unidade com id ({id}) não foi encontrada");

            if(!string.IsNullOrEmpty(entity.UnitName))
                unitId.UnitName = entity.UnitName;

            if (!string.IsNullOrEmpty(entity.UnitCode))
                unitId.UnitCode = entity.UnitCode;

            if (!string.IsNullOrEmpty(entity.Status.ToString()))
                unitId.Status = entity.Status;

            if (propertyUnitName != null || propertyUnitCode != null)
                throw new BadRequestException("Já existe uma unidade com estás informações de nome de unidade ou código da unidade");

            if (propertyUnitName != null || propertyUnitCode != null)
                throw new BadRequestException("Já existe uma unidade com estás informações de nome de unidade ou código da unidade");


            var unitValidation = await _validations.ValidateAsync(unitId);

            if (!unitValidation.IsValid)
                throw new ValidationException(unitValidation.Errors);

            _unitRepository.Update(unitId);
            await _uow.Commit();


            return $"Usário com id ({unitId.Id}), foi atualizado com sucesso";


        }
    }
}
