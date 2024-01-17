
namespace DesafioRodonaves.Application.Interfaces
{
    public interface IServiceBase<TEntity>
    {
        Task<IEnumerable<TEntity>> GetAll();

        Task<TEntity> GetById(int id);

        Task<string> Create(TEntity entity);

        void Update(TEntity entity);

        void Delete(TEntity entity);
    }
}

