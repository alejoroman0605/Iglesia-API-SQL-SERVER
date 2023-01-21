using Library.Data;
using Library.Data.Interfaces;
using Library.Data.Models;
using Library.Repository.Interfaces;
using Library.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq.Expressions;

namespace Library.Repository.Services
{
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : EntityBase
    {
        protected readonly IBaseRepository<TEntity> _baseRepository;
        protected readonly IUnitOfWork _repositories;

        public BaseService(IUnitOfWork repositories, IBaseRepository<TEntity> baseRepository)
        {
            _baseRepository = baseRepository;
            _repositories = repositories;
        }

        public virtual async Task<EntityEntry<TEntity>> AddAsync(TEntity entity) => await _baseRepository.AddAsync(entity);
        public virtual EntityEntry<TEntity> Delete(TEntity entity) => _baseRepository.Remove(entity);
        public virtual async Task<EntityEntry<TEntity>> Delete(int id) {
            var entity = await FindByIdAsync(id);
            if(entity == null)
                return null;
            return _baseRepository.Remove(entity);
        } 
        public virtual async Task<int> SaveChangesAsync() => await _baseRepository.SaveChangesAsync();
        public virtual EntityEntry<TEntity> Update(TEntity entity) => _baseRepository.Update(entity);
        public virtual void UpdateRange(List<TEntity> entities) => _baseRepository.UpdateRange(entities);
        public virtual async Task<TEntity?> FindByIdAsync(int id) => await _baseRepository.FirstAsync(entity=> entity.Id == id);
        public virtual async Task<IEnumerable<TEntity>> GetAllAsync() => await _baseRepository.GetAllAsync();

        
        protected virtual IQueryable<TEntity> CreateQuery()
        {
            return _baseRepository.GetQuery(); 
        }

        public virtual async Task<(IEnumerable<TEntity>, int)> GetPagedListAsync(int skipCount, int? maxResultCount, params Expression<Func<TEntity, bool>>[] filters)
        {
            IQueryable<TEntity> query = CreateQuery();

            //Filtering
            query = filters.Aggregate(query, (current, filters) => current.Where(filters));
            //Counting
            int total = await query.CountAsync();
            //Paginating
            query = query.Skip(skipCount).Take(maxResultCount.GetValueOrDefault(total));

            return (await query.ToListAsync(), total);
        }
        
        public Task<TEntity> UpdateModel(TEntity entity)
        {
            return _baseRepository.UpdateModel(entity);
        }

    }
}