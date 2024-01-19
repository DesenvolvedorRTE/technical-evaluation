
using DesafioRodonaves.Domain.Entities;

namespace DesafioRodonaves.Domain.Interfaces
{
    public interface IUserRepository : IRepositoryBase<User>
    {
        Task<User> PropertyLoginExist(string login);

        Task<IEnumerable<User>> GetAllUserByStatus(bool status);

        Task<User> CheckDataLogin(string login);
    }
}
