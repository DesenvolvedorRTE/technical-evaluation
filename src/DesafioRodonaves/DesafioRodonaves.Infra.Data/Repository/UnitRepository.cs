
using DesafioRodonaves.Domain.Entities;
using DesafioRodonaves.Domain.Interfaces;
using DesafioRodonaves.Infra.Data.Context;

namespace DesafioRodonaves.Infra.Data.Repository
{
    public class UnitRepository : RepositoryBase<Unit>, IUnitRepository
    {
        private readonly ApplicationDbContext _context;

        public UnitRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
