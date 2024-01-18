using DesafioRodonaves.Application.Commads.Request.User;
using DesafioRodonaves.Application.Commads.Response.User;

namespace DesafioRodonaves.Application.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<GetAllUserDTOResponse>> GetAll();

        Task<GetUserByIdDTOResponse> GetById(int id);

        Task<string> Update(UpdateUserDTORequest entity, int id);

        Task<string> Delete(int id);
    }
}
