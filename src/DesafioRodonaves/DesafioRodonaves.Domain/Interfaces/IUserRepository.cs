
using DesafioRodonaves.Domain.Entities;
using System.Diagnostics;

namespace DesafioRodonaves.Domain.Interfaces
{
    public interface IUserRepository : IRepositoryBase<User>
    {
        Task<User> PropertyLoginExist(string login);
    }
}
