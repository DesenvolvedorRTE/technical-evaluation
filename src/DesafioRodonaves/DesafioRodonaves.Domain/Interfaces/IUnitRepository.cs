
using DesafioRodonaves.Domain.Entities;

namespace DesafioRodonaves.Domain.Interfaces
{
    public interface IUnitRepository : IRepositoryBase<Unit>
    {
        Task<Unit> PropertyUnitNameExists(string unitName);
        Task<Unit> PropertyUnitCodeExists(string unitCode);
    }
}
