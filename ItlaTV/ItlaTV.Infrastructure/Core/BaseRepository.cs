
using ItlaTV.Domain.Repository;
using ItlaTV.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace ItlaTV.Infrastructure.Core
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        private readonly ApplicationContext _context;
        private readonly DbSet<TEntity> _myDbSet;

        public BaseRepository(ApplicationContext context) {
            _context = context;
            _myDbSet = _context.Set<TEntity>();
        }
        public async virtual Task<TEntity> GetEntity(int id)
        {
           return await _myDbSet.FindAsync(id);
        }
        public async virtual Task<IEnumerable<TEntity>> GetEntities()
        {
            return await _myDbSet.ToListAsync();
        }
        public async virtual Task Add(TEntity entity)
        {
            await _myDbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }
        public async virtual Task Update(TEntity entity)
        {
            _myDbSet.Update(entity);
            await _context.SaveChangesAsync();
        }
        public async virtual Task Remove(TEntity entity)
        {
           _myDbSet.Remove(entity);
            await _context.SaveChangesAsync();
        }
        public async virtual Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
    }
}
