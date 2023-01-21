using Library.Data.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq.Expressions;

namespace Library.Data.Interfaces
{
    public interface IBaseRepository<TEntity> where TEntity : EntityBase
    {
        /// <summary>
        /// add an entity
        /// </summary>
        Task<EntityEntry<TEntity>> AddAsync(TEntity entity);
        /// <summary>
        /// add many entities
        /// </summary>
        Task AddRangeAsync(IEnumerable<TEntity> entities);
        /// <summary>
        /// validate if exist any entity
        /// </summary>
        Task<bool> AnyAsync();
        /// <summary>
        /// validate if exist any entity that meets the condition 
        /// </summary>
        Task<bool> AnyAsync(Expression<Func<TEntity, bool>> condition);
        /// <summary>
        /// validate if exist the entity
        /// </summary>
        Task<bool> ContainsAsync(TEntity entity);
        /// <summary>
        /// count all entities
        /// </summary>
        Task<int> CountAsync(TEntity entity);
        /// <summary>
        /// count all entities that meets the condition
        /// </summary>
        Task<int> CountAsync(Expression<Func<TEntity, bool>> condition);
        /// <summary>
        /// get first entity that meets the condition
        /// </summary>
        Task<TEntity?> FirstAsync(Expression<Func<TEntity, bool>> condition, params Expression<Func<TEntity, object>>[] includeProperties);
        /// <summary>
        /// get all entities that meet the condition
        /// </summary>
        Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> condition, params Expression<Func<TEntity, object>>[] includeProperties);
        /// <summary>
        /// get all entities
        /// </summary>
        Task<List<TEntity>> GetAllAsync(params Expression<Func<TEntity, object>>[] includeProperties);
        /// <summary>
        /// get entity by id
        /// </summary>
        Task<TEntity?> GetByIdAsync(int id);
        /// <summary>
        /// get entity by id 
        /// </summary>
        Task<TEntity?> GetByIdAsync(int id, params Expression<Func<TEntity, object>>[] includeProperties);
        IQueryable<TEntity> GetQuery(params Expression<Func<TEntity, object>>[] includeProperties);

        /// <summary>
        /// get last entity
        /// </summary>
        Task<TEntity?> LastAsync(params Expression<Func<TEntity, object>>[] includeProperties);
        /// <summary>
        /// get last entity that meets the condition
        /// </summary>
        Task<TEntity?> LastAsync(Expression<Func<TEntity, bool>> condition, params Expression<Func<TEntity, object>>[] includeProperties);
        /// <summary>
        /// remove an entity
        /// </summary>
        EntityEntry<TEntity> Remove(TEntity entity);
        /// <summary>
        /// remove entity by Id
        /// </summary>
        Task<EntityEntry<TEntity>?> RemoveByIdAsync(int id);
        /// <summary>
        /// remove many entities
        /// </summary>
        void RemoveRange(IEnumerable<TEntity> entities);
        /// <summary>
        /// save all changes
        /// </summary>
        /// <returns></returns>
        Task<int> SaveChangesAsync();
        /// <summary>
        /// update an entity
        /// </summary>
        Task<TEntity> UpdateModel(TEntity obj);
        EntityEntry<TEntity> Update(TEntity entity);
        /// <summary>
        /// update many entities
        /// </summary>
        void UpdateRange(List<TEntity> entities);
    }
}
