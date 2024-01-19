using DesafioRodonaves.Application.Commads.Request.User;
using DesafioRodonaves.Application.Commads.Response.User;
using DesafioRodonaves.Application.Interfaces;
using DesafioRodonaves.Domain.Commons.Execptions;
using DesafioRodonaves.Domain.Interfaces;
using DesafioRodonaves.Domain.Validations;
using DesafioRodonaves.Infra.Data.Context;
using Mapster;

namespace DesafioRodonaves.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork<ApplicationDbContext> _uow;
        private readonly UserValidation _userValidator;
        private readonly IPasswordManager _passwordManger;
        private readonly TokenService _tokenService;

        public UserService(IUserRepository userRepository, IUnitOfWork<ApplicationDbContext> uow, UserValidation userValidator, IPasswordManager passwordManger, TokenService tokenService)
        {
            _userRepository = userRepository;
            _uow = uow;
            _userValidator = userValidator;
            _passwordManger = passwordManger;
            _tokenService = tokenService;
        }

        public async Task<IEnumerable<GetAllUserDTOResponse>> GetAll()
        {
            var userResponse = await _userRepository.GetAll();

            return userResponse.Adapt<IEnumerable<GetAllUserDTOResponse>>();
        }

        public async Task<GetUserByIdDTOResponse> GetById(int id)
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

        public async Task<IEnumerable<GetAllUserByStatusDTOResponse>> GetAllUserByStatus(bool status)
        {
            var userStatus = await _userRepository.GetAllUserByStatus(status);

            return userStatus.Adapt<IEnumerable<GetAllUserByStatusDTOResponse>>();
        }

        public async Task<LoginDTOResponse> Login(LoginDTORequest request)
        {
            if (string.IsNullOrEmpty(request.Login) || string.IsNullOrEmpty(request.Password))
                throw new BadRequestException("Dados inválidos");

            var userLogin = await _userRepository.CheckDataLogin(request.Login.ToLower());
            var verifyPassword = _passwordManger.VerifyPassword(userLogin.Password, request.Password);

            if (userLogin is null)
                throw new ForbiddenException("Usuário ou senha inválido.");

            if (userLogin == null || verifyPassword == false)
                throw new BadRequestException("Usuário ou senha inválido.");

            // Gera o token de autenticação usando o serviço de token
            var token = await _tokenService.GenerateToken(userLogin);

            return new LoginDTOResponse() { Token = token };
        }
    }
}