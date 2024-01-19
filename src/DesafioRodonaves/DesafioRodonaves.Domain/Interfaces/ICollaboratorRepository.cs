using DesafioRodonaves.Domain.Entities;

namespace DesafioRodonaves.Domain.Interfaces
{
    public interface ICollaboratorRepository : IRepositoryBase<Collaborator>
    {
        Task<Collaborator> GetUserByUnitId(int unitId);
    }
}