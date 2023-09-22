
namespace ItlaTV.Domain.Repository
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        Task Add(TEntity entity);
        Task Update(TEntity entity);
        Task Remove(TEntity entity);
        Task<TEntity> GetEntity(int id);
        Task<IEnumerable<TEntity>> GetEntities();
        Task SaveChanges();
    }
}
