using DesafioRodonaves.Domain.Entities;
using DesafioRodonaves.Domain.Interfaces;
using DesafioRodonaves.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace DesafioRodonaves.Infra.Data.Repository
{
    public class UnitRepository : RepositoryBase<Unit>, IUnitRepository
    {
        private readonly ApplicationDbContext _context;

        public UnitRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Unit>> GetAllUnitAndAllCollaboratorAssociate()
        {
            // Inclui os colaboradores relacionados com cada unidade
            return await _context.Units
                .Include(unit => unit.Collaborator)
                .Where(x => x.Collaborator.Any())
                .ToListAsync();
        }

        public async Task<Unit> PropertyUnitCodeExists(string unitCode)
        {
            return await _context.Units.AsNoTracking().FirstOrDefaultAsync(u => u.UnitCode == unitCode);
        }

        public async Task<Unit> PropertyUnitNameExists(string unitName)
        {
            return await _context.Units.AsNoTracking().FirstOrDefaultAsync(u => u.UnitName == unitName);
        }
    }
}