
using DesafioRodonaves.Domain.Entities;
using DesafioRodonaves.Domain.Interfaces;
using DesafioRodonaves.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace DesafioRodonaves.Infra.Data.Repository
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public UserRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<User> PropertyLoginExist(string login)
        {
            return await _dbContext.Users.AsTracking().FirstOrDefaultAsync(u => u.Login == login);
        }
    }
}
