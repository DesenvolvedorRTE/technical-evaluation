
using DesafioRodonaves.Application.Commads.Request.Collaborator;
using DesafioRodonaves.Application.Commads.Response.Collaborator;
using DesafioRodonaves.Application.Interfaces;
using DesafioRodonaves.Domain.Commons.Execptions;
using DesafioRodonaves.Domain.Entities;
using DesafioRodonaves.Domain.Interfaces;
using DesafioRodonaves.Domain.Validations;
using DesafioRodonaves.Infra.Data.Context;
using FluentValidation;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace DesafioRodonaves.Application.Services
{
    public class CollaboratorService : ICollaboratorService
    {
        private readonly CollaboratorValidation _collaboratorValidation;
        private readonly UserValidation _userValidation;
        private readonly ICollaboratorRepository _collaboratorRepository;
        private readonly IUserRepository _userRepository;
        private readonly IUnitRepository _unitRepository;
        private readonly IUnitOfWork<ApplicationDbContext> _uow;
        private readonly IPasswordManager _passwordManager;
      

        public CollaboratorService(CollaboratorValidation collaboratorValidation, UserValidation userValidation, ICollaboratorRepository collaboratorRepository,
            IUserRepository userRepository, IUnitRepository unitRepository, IUnitOfWork<ApplicationDbContext> uow, IPasswordManager passwordManager)
        {
            _collaboratorValidation = collaboratorValidation;
            _userValidation = userValidation;
            _collaboratorRepository = collaboratorRepository;
            _userRepository = userRepository;
            _unitRepository = unitRepository;
            _uow = uow;
            _passwordManager = passwordManager;
        }

        public async Task<string> Create(CreateCollaboratorDTORequest entity)
        {

                // Validação da unidade
                var unitId = await _unitRepository.GetById(entity.UnitId);

                if (unitId == null)
                    throw new NotFoundException($"A unidade com id ({entity.UnitId}) não existe, realize o cadastro da unidade em seu módulo");

                if (unitId.Status == false)
                    throw new BadRequestException("A unidade informada está inativa. Por favor, selecione outra unidade ativa.");


                // Criação do usuário
                User user = new()
                {
                    Login = entity.User.Login,
                    Password = entity.User.Password,
                    Status = entity.User.Status
                };

                // Validação do colaborador
                Collaborator collaborator = new()
                {
                    Id = 0,
                    Name = entity.Name,
                    UnitId = entity.UnitId,
                    UserId = 0
                };

                var collaboratorValidation = await _collaboratorValidation.ValidateAsync(collaborator);

                if (!collaboratorValidation.IsValid)
                    throw new ValidationException(collaboratorValidation.Errors);

                var userLogin = await _userRepository.PropertyLoginExist(entity.User.Login);

                if (userLogin != null)
                    throw new BadRequestException("Já existe um usuário com este login, tente novamente");

                // Validação do usuário
                var userValidation = await _userValidation.ValidateAsync(user);

                if (!userValidation.IsValid)
                    throw new ValidationException(userValidation.Errors);

                user.Password = _passwordManager.HashPassword(user.Password);

                // Criação do usuário no repositório
                await _userRepository.Create(user);

                // Commit da transação (se estiver usando Unit of Work)
                await _uow.Commit();

                // Associação do usuário ao colaborador
                collaborator.UserId = user.Id;

                // Criação do colaborador no repositório
                await _collaboratorRepository.Create(collaborator);

                // Commit da transação novamente (se estiver usando Unit of Work)
                await _uow.Commit();

                return $"Colaborador com id ({collaborator.Id}) e Usuário com id ({user.Id}), foi criado com sucesso";
            
           
        }

        public async Task<string> Delete(int id)
        {
            var collaboratorId = await _collaboratorRepository.GetById(id);

            if (collaboratorId is null)
                throw new NotFoundException($"Colaborador com id ({id}), não foi encontrado");

            // Excluir o usuario e o cobalorador associado a ele.
            var userID = await _userRepository.GetById(id);

            _userRepository.Delete(userID);
            await _uow.Commit();

            return $"Colaborador com id ({id}), foi removido com sucesso\n" +
                $"Obs: O usuário relacionando a ele também foi excluido";

        }

        public async Task<IEnumerable<GetAllCollaboratorDTOResponse>> GetAll()
        {
            var collaborators = await _collaboratorRepository.GetAll();

            return collaborators.Adapt<IEnumerable<GetAllCollaboratorDTOResponse>>();
        }

        public async Task<GetCollaboratorByIdDTOResponse> GetById(int id)
        {
            var collaboratorId = await _collaboratorRepository.GetById(id);

            if (collaboratorId is null)
                throw new NotFoundException($"Colaborador com id ({id}), não foi encontrado");

            return collaboratorId.Adapt<GetCollaboratorByIdDTOResponse>();
        }

        public async Task<string> Update(UpdateCollaboratorDTORequest entity, int id)
        {
            var collaboratorId = await _collaboratorRepository.GetById(id);

            if (collaboratorId is null)
                throw new NotFoundException($"Colaborador com id ({id}), não foi encontrado");

       
            if (!string.IsNullOrEmpty(entity.Name))
                collaboratorId.Name = entity.Name;

            if (!string.IsNullOrEmpty(entity.UnitId.ToString()))
            {
                collaboratorId.UnitId = entity.UnitId;
                var unitId = await _unitRepository.GetById(entity.UnitId.Value);

                if (unitId == null)
                    throw new NotFoundException($"A unidade com id ({entity.UnitId}) não existe, realize o cadastro da unidade em seu módulo");
            }


            var collaboratorValidation = await _collaboratorValidation.ValidateAsync(collaboratorId);

            if (!collaboratorValidation.IsValid)
                throw new ValidationException(collaboratorValidation.Errors);

            _collaboratorRepository.Update(collaboratorId);

            return $"Colaborador com id ({id}), foi atualizado com sucesso";
        }
    }
}
