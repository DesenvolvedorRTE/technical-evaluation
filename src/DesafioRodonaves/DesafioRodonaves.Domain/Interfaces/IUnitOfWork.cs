namespace DesafioRodonaves.Domain.Interfaces
{
    public interface IUnitOfWork<TDbContext>
    {
        Task<bool> Commit();

        void Rollback();
    }
}