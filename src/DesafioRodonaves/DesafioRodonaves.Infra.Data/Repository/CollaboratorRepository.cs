using DesafioRodonaves.Domain.Entities;
using DesafioRodonaves.Domain.Interfaces;
using DesafioRodonaves.Infra.Data.Context;

namespace DesafioRodonaves.Infra.Data.Repository
{
    public class CollaboratorRepository : RepositoryBase<Collaborator>, ICollaboratorRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public CollaboratorRepository(ApplicationDbContext dbContext) : base(dbContext) 
        {
            _dbContext = dbContext;
        }   
    }
}
