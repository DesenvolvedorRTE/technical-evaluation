
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

        public async Task<User> CheckDataLogin(string login)
        {
            return await _dbContext.Users.AsNoTracking().FirstOrDefaultAsync(l => l.Login == login);
        }

        public async Task<IEnumerable<User>> GetAllUserByStatus(bool status)
        {
            if (status == false)
                return await _dbContext.Users.Where(x => x.Status == false).ToListAsync();

            return await _dbContext.Users.Where(x => x.Status == true).ToListAsync();
        }

        public async Task<User> PropertyLoginExist(string login)
        {
            return await _dbContext.Users.AsTracking().FirstOrDefaultAsync(u => u.Login == login);
        }
    }
}
