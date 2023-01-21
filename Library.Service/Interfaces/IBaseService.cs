using Library.Data;
using Library.Data.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq.Expressions;

namespace Library.Service.Interfaces
{
    public interface IBaseService<TEntity> where TEntity : EntityBase
    {
       
        EntityEntry<TEntity> Update(TEntity entity);
        /// <summary>
        /// Remove an entity from database
        /// </summary>
        EntityEntry<TEntity> Delete(TEntity entity);
        /// <summary>
        /// Update many entities from database
        /// </summary>
        void UpdateRange(List<TEntity> entities);
        /// <summary>
        /// Find an entity by Id
        /// </summary>
        Task<TEntity?> FindByIdAsync(int id);
        /// <summary>
        /// Save All Changes in database
        /// </summary>
        Task<int> SaveChangesAsync();
        /// <summary>
        /// Get entities list paginated
        /// </summary>
        Task<(IEnumerable<TEntity>, int)> GetPagedListAsync(int skipCount, int? maxResultCount, params Expression<Func<TEntity, bool>>[] filters);
        /// <summary>
        /// Get all entities 
        /// </summary>
        Task<IEnumerable<TEntity>> GetAllAsync();
        /// <summary>
        /// Add an entity
        /// </summary>
        Task<EntityEntry<TEntity>> AddAsync(TEntity entity);
        Task<TEntity> UpdateModel(TEntity entity);
        Task<EntityEntry<TEntity>> Delete(int id);

    }
}