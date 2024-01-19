using DesafioRodonaves.Application.Commads.Request.User;
using DesafioRodonaves.Application.Commads.Response.User;
using DesafioRodonaves.Domain.Entities;

namespace DesafioRodonaves.Application.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<GetAllUserDTOResponse>> GetAll();

        Task<GetUserByIdDTOResponse> GetById(int id);

        Task<string> Update(UpdateUserDTORequest entity, int id);

        Task<IEnumerable<GetAllUserByStatusDTOResponse>> GetAllUserByStatus(bool status);

        Task<LoginDTOResponse> Login(LoginDTORequest login);
        

    }
}
