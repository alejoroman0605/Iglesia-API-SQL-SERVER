using Library.Data.DataDBContext;
using Library.Data.Interfaces;
using Library.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq.Expressions;

namespace Library.Data.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : EntityBase
    {
        protected readonly DataContext _context;

        public BaseRepository(DataContext context)
        {
            _context = context;
        }
        
        public virtual async Task<EntityEntry<TEntity>> AddAsync(TEntity entity) => await _context.Set<TEntity>().AddAsync(entity);
        public virtual async Task AddRangeAsync(IEnumerable<TEntity> entities) => await _context.Set<TEntity>().AddRangeAsync(entities);
        public virtual async Task<bool> AnyAsync() => await _context.Set<TEntity>().AnyAsync();
        public virtual async Task<bool> ContainsAsync(TEntity entity) => await _context.Set<TEntity>().ContainsAsync(entity);
        public virtual async Task<int> CountAsync(TEntity entity) => await _context.Set<TEntity>().CountAsync();
        public virtual async Task<List<TEntity>> GetAllAsync(params Expression<Func<TEntity, object>>[] includeProperties) => await GetQuery(includeProperties).OrderBy(x => x.Id).ToListAsync();
        public virtual async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> condition, params Expression<Func<TEntity, object>>[] includeProperties) => await GetQuery(includeProperties).Where(condition).ToListAsync();
        public virtual async Task<TEntity?> GetByIdAsync(int id) => await _context.Set<TEntity>().FindAsync(id);
        public virtual async Task<TEntity?> GetByIdAsync(int id, params Expression<Func<TEntity, object>>[] includeProperties) => await GetQuery(includeProperties).FirstOrDefaultAsync(e=> e.Id == id);
        public virtual EntityEntry<TEntity> Remove(TEntity entity) => _context.Set<TEntity>().Remove(entity);
        public virtual void RemoveRange(IEnumerable<TEntity> entities) => _context.Set<TEntity>().RemoveRange(entities);
        public virtual EntityEntry<TEntity> Update(TEntity entity) => _context.Set<TEntity>().Update(entity);
        public virtual void UpdateRange(List<TEntity> entities) => _context.Set<TEntity>().UpdateRange(entities);
        public virtual async Task<TEntity?> LastAsync(params Expression<Func<TEntity, object>>[] includeProperties) => await GetQuery(includeProperties).LastOrDefaultAsync();
        public virtual async Task<TEntity?> FirstAsync(Expression<Func<TEntity, bool>> condition, params Expression<Func<TEntity, object>>[] includeProperties) => await GetQuery(includeProperties).FirstOrDefaultAsync(condition);
        public virtual async Task<TEntity?> LastAsync(Expression<Func<TEntity, bool>> condition, params Expression<Func<TEntity, object>>[] includeProperties) => await GetQuery(includeProperties).LastOrDefaultAsync(condition);
        public virtual async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> condition) => await _context.Set<TEntity>().AnyAsync(condition);
        public virtual async Task<int> CountAsync(Expression<Func<TEntity, bool>> condition) => await _context.Set<TEntity>().CountAsync(condition);
        public virtual async Task<int> SaveChangesAsync() => await _context.SaveChangesAsync();

        public virtual async Task<EntityEntry<TEntity>?> RemoveByIdAsync(int id)
        {
            TEntity? entity = await GetByIdAsync(id);

            if (entity != null)
                return _context.Set<TEntity>().Remove(entity);

            return null;
        }

        public virtual IQueryable<TEntity> GetQuery(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> query = _context.Set<TEntity>();
            return includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
        }

        public async Task<TEntity> UpdateModel(TEntity obj)
        {
            _context.ChangeTracker.Clear();
            _context.Entry(obj).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return obj;
        }

        public IQueryable<TEntity> GetQuery(List<string> navigationPropertiesPath)
        {
            IQueryable<TEntity> query = _context.Set<TEntity>();
            if (navigationPropertiesPath != null)
                navigationPropertiesPath.ForEach(property => query.Include(property));
            return query;
        }
    }
}
