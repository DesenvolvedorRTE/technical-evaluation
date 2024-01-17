
namespace DesafioRodonaves.Application.Interfaces
{
    public interface IServiceBase<TEntity>
    {
        Task<IEnumerable<TEntity>> GetAll();

        Task<TEntity> GetById(int id);

        Task<string> Create(TEntity entity);

        Task<string> Update(TEntity entity, int id);

        void Delete(TEntity entity);
    }
}

