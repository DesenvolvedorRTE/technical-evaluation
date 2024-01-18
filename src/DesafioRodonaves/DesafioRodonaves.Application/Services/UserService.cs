
using DesafioRodonaves.Application.Commads.Request.User;
using DesafioRodonaves.Application.Commads.Response.User;
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
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork<ApplicationDbContext> _uow;
        private readonly UserValidation _userValidator;
        private readonly IPasswordManager _passwordManger;

        public UserService(IUserRepository userRepository, IUnitOfWork<ApplicationDbContext> uow, 
            UserValidation userValidator, IPasswordManager passwordManger)
        {
            _userRepository = userRepository;
            _uow = uow;
            _userValidator = userValidator;
            _passwordManger = passwordManger;
        }

        public async Task<IEnumerable<GetAllUserDTOResponse>> GetAll()
        {
           var userResponse = await _userRepository.GetAll();

            return userResponse.Adapt<IEnumerable<GetAllUserDTOResponse>>();
        }

        public async  Task<GetUserByIdDTOResponse> GetById(int id)
        {
            var userId = await _userRepository.GetById(id);

            if (userId is null)
                throw new NotFoundException($"Usuário com id ({id}), não foi encontrando");

            return userId.Adapt<GetUserByIdDTOResponse>();
        }

        public async Task<string> Update(UpdateUserDTORequest entity, int id)
        {
            var userId = await _userRepository.GetById(id);

            // Verifica se o usuário existe
            if (userId is null)
                throw new NotFoundException($"Usuário com id ({id}), não foi encontrando");

            if (!string.IsNullOrEmpty(entity.Password))
            {
                userId.Password = entity.Password;
                userId.Password = _passwordManger.HashPassword(userId.Password);
            }
            

            if (!string.IsNullOrEmpty(entity.Status.ToString()))
                userId.Status = entity.Status;

            _userRepository.Update(userId);
            await _uow.Commit();

            return $"Usuário com id ({id}), foi atualizado com sucesso";
        }
    }
}
