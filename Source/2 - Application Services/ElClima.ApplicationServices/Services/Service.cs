using ElClima.Domain.Core.DependencyInjection;
using ElClima.Domain.Core.Entities;
using ElClima.Domain.Core.Lists;
using ElClima.Domain.Core.Repository;
using ElClima.Domain.Core.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ElClima.ApplicationServices.Services
{
    public class Service<TEntity> : IService<TEntity> where TEntity : BaseEntity
    {
        protected readonly IUnitOfWork UnitOfWork;
        private readonly IRepository<TEntity> _repository;

        public Service()
        {
            var provider = ServiceReference.GetServiceProvider();

            //var services = new ServiceCollection();
            //var provider = services.BuildServiceProvider();

            var uowFactory = ServiceReference.GetService<IUnitOfWorkFactory>();
            UnitOfWork = uowFactory.GetNewUnitOfWork(provider);
            _repository = UnitOfWork.Repository<TEntity>();
        }

        public Service(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
            _repository = UnitOfWork.Repository<TEntity>();
        }

        public IUnitOfWork GetCurrentUnitOfWork()
        {
            return UnitOfWork;
        }

        public DbSet<TEntity> GetEntitySet()
        {
            return _repository.GetEntitySet();
        }

        public TEntity GetOne(int id)
        {
            return _repository.GetOne(id);
        }

        public TResult GetOneBySelector<TResult>(int id,
            Expression<Func<TEntity, TResult>> selector)
        {
            return _repository.GetOneBySelector<TResult>(id, selector);
        }


        public TEntity GetOneIncluding(int id,
            params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return _repository.GetOneIncluding(id, includeProperties);
        }

        public TEntity GetOneByQuery(IQueryable<TEntity> query)
        {
            return _repository.GetOneByQuery(query);
        }



        public List<TEntity> GetAll()
        {
            return _repository.GetAll();
        }

        public List<TResult> GetAllBySelector<TResult>(Expression<Func<TEntity, TResult>> selector)
        {
            return _repository.GetAllBySelector<TResult>(selector);
        }

        public List<TEntity> GetAllIncluding(
            params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return _repository.GetAllIncluding(includeProperties);
        }

        public List<TEntity> GetAll(
            Expression<Func<TEntity, object>> orderBy,
            OrderDirection orderDirection = OrderDirection.Ascending)
        {
            return _repository.GetAll(orderBy, orderDirection);
        }

        public List<TResult> GetAllBySelector<TResult>(
            Expression<Func<TEntity, TResult>> selector,
            Expression<Func<TEntity, object>> orderBy,
            OrderDirection orderDirection = OrderDirection.Ascending)
        {
            return _repository.GetAllBySelector<TResult>(selector, orderBy, orderDirection);
        }

        public List<TEntity> GetAllIncluding(
            Expression<Func<TEntity, object>> orderBy,
            OrderDirection orderDirection = OrderDirection.Ascending,
            params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return _repository.GetAllIncluding(orderBy, orderDirection, includeProperties);
        }


        public PaginatedList<TEntity> GetPage(int pageIndex, int pageSize)
        {
            return _repository.GetPage(pageIndex, pageSize);
        }

        public PaginatedList<TResult> GetPageBySelector<TResult>(
            int pageIndex,
            int pageSize,
            Expression<Func<TEntity, TResult>> selector)
        {
            return _repository.GetPageBySelector<TResult>(pageIndex, pageSize, selector);
        }

        public PaginatedList<TEntity> GetPageIncluding(
            int pageIndex,
            int pageSize,
            params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return _repository.GetPageIncluding(pageIndex, pageSize, includeProperties);
        }


        public PaginatedList<TEntity> GetPage(
            int pageIndex,
            int pageSize,
            Expression<Func<TEntity, object>> orderBy,
            OrderDirection orderDirection = OrderDirection.Ascending)
        {
            return _repository.GetPage(pageIndex, pageSize, orderBy, orderDirection);
        }

        public PaginatedList<TResult> GetPageBySelector<TResult>(
            int pageIndex,
            int pageSize,
            Expression<Func<TEntity, TResult>> selector,
            Expression<Func<TEntity, object>> orderBy,
            OrderDirection orderDirection = OrderDirection.Ascending)
        {
            return _repository.GetPageBySelector<TResult>(pageIndex, pageSize, selector, orderBy, orderDirection);
        }

        public PaginatedList<TEntity> GetPageIncluding(
            int pageIndex,
            int pageSize,
            Expression<Func<TEntity, object>> orderBy,
            OrderDirection orderDirection = OrderDirection.Ascending,
            params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return _repository.GetPageIncluding(pageIndex, pageSize, orderBy,
                orderDirection, includeProperties);
        }

        public PaginatedList<TResult> GetPageBySelectorIncluding<TResult>(int pageIndex, int pageSize, Expression<Func<TEntity, TResult>> selector, Expression<Func<TEntity, object>> orderBy,
            OrderDirection orderDirection = OrderDirection.Ascending, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return _repository.GetPageBySelectorIncluding(
                pageIndex, pageSize, selector, orderBy, orderDirection, includeProperties);
        }


        public PaginatedList<TEntity> GetPageByFilter(
            int pageIndex,
            int pageSize,
            Expression<Func<TEntity, bool>> filter,
            Expression<Func<TEntity, object>> orderBy,
            OrderDirection orderDirection)
        {
            return _repository.GetPageByFilterIncluding(pageIndex, pageSize, filter,
                orderBy, orderDirection, null);
        }

        public PaginatedList<TResult> GetPageByFilterBySelector<TResult>(
            int pageIndex,
            int pageSize,
            Expression<Func<TEntity, TResult>> selector,
            Expression<Func<TEntity, bool>> filter,
            Expression<Func<TEntity, object>> orderBy,
            OrderDirection orderDirection)
        {
            return _repository.GetPageByFilterBySelector(pageIndex, pageSize, selector,
                filter, orderBy, orderDirection);
        }

        public PaginatedList<TResult> GetPageByFilterBySelectorIncluding<TResult>(int pageIndex, int pageSize, Expression<Func<TEntity, TResult>> selector,
            Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, object>> orderBy, OrderDirection orderDirection, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return _repository.GetPageByFilterBySelectorIncluding(pageIndex, pageSize, selector,
                filter, orderBy, orderDirection, includeProperties);
        }


        public PaginatedList<TEntity> GetPageByFilterIncluding(
            int pageIndex,
            int pageSize,
            Expression<Func<TEntity, bool>> filter,
            Expression<Func<TEntity, object>> orderBy,
            OrderDirection orderDirection,
            params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return _repository.GetPageByFilterIncluding(pageIndex, pageSize, filter, orderBy, orderDirection, includeProperties);
        }


        public List<TEntity> GetByFilter(Expression<Func<TEntity, bool>> filter)
        {
            return _repository.GetByFilter(filter);
        }

        public List<TResult> GetByFilterBySelector<TResult>(
            Expression<Func<TEntity, TResult>> selector,
            Expression<Func<TEntity, bool>> filter)
        {
            return _repository.GetByFilterBySelector(selector, filter);
        }

        public List<TResult> GetByFilterBySelectorIncluding<TResult>(Expression<Func<TEntity, TResult>> selector, Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, object>> orderBy,
            OrderDirection orderDirection, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return _repository.GetByFilterBySelectorIncluding(selector, filter, orderBy, orderDirection, includeProperties);
        }

        public List<TEntity> GetByFilterIncluding(
            Expression<Func<TEntity, bool>> filter,
            params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return _repository.GetByFilterIncluding(filter, includeProperties);
        }


        public List<TEntity> GetByFilter(
            Expression<Func<TEntity, bool>> filter,
            Expression<Func<TEntity, object>> orderBy,
            OrderDirection orderDirection)
        {
            return _repository.GetByFilter(filter,
                orderBy, orderDirection);
        }

        public List<TResult> GetByFilterBySelector<TResult>(
            Expression<Func<TEntity, TResult>> selector,
            Expression<Func<TEntity, bool>> filter,
            Expression<Func<TEntity, object>> orderBy,
            OrderDirection orderDirection)
        {

            return _repository.GetByFilterBySelector<TResult>(selector, filter,
                orderBy, orderDirection);
        }


        public List<TEntity> GetByFilterIncluding(
            Expression<Func<TEntity, bool>> filter,
            Expression<Func<TEntity, object>> orderBy,
            OrderDirection orderDirection,
            params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return _repository.GetByFilterIncluding(filter, orderBy,
                orderDirection, includeProperties);
        }


        public void Insert(TEntity entity)
        {
            _repository.Insert(entity);
            UnitOfWork.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            _repository.Update(entity);
            UnitOfWork.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            _repository.Delete(entity);
            UnitOfWork.SaveChanges();
        }


        public Task<TEntity> GetOneAsync(int id)
        {
            return _repository.GetOneAsync(id);
        }

        public Task<TResult> GetOneBySelectorAsync<TResult>(
            int id,
            Expression<Func<TEntity, TResult>> selector)
        {
            return _repository.GetOneBySelectorAsync(id, selector);
        }

        public Task<TEntity> GetOneIncludingAsync(
            int id,
            params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return _repository.GetOneIncludingAsync(id, includeProperties);
        }


        public Task<List<TEntity>> GetAllAsync()
        {
            return _repository.GetAllAsync();
        }

        public Task<List<TResult>> GetAllBySelectorAsync<TResult>(
            Expression<Func<TEntity, TResult>> selector)
        {
            return _repository.GetAllBySelectorAsync(selector);
        }

        public Task<List<TEntity>> GetAllIncludingAsync(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return _repository.GetAllIncludingAsync(includeProperties);
        }



        public Task<PaginatedList<TEntity>> GetPageAsync(int pageIndex, int pageSize)
        {
            return _repository.GetPageAsync(pageIndex, pageSize);
        }

        public Task<PaginatedList<TResult>> GetPageBySelectorAsync<TResult>(
            int pageIndex,
            int pageSize,
            Expression<Func<TEntity, TResult>> selector)
        {
            return _repository.GetPageBySelectorAsync<TResult>(pageIndex, pageSize, selector);
        }

        public async Task<PaginatedList<TEntity>> GetPageIncludingAsync(
            int pageIndex,
            int pageSize,
            params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return await _repository.GetPageIncludingAsync(pageIndex, pageSize
                , includeProperties);
        }


        public Task<PaginatedList<TEntity>> GetPageAsync(
            int pageIndex,
            int pageSize,
            Expression<Func<TEntity, object>> orderBy,
            OrderDirection orderDirection = OrderDirection.Ascending)
        {
            return _repository.GetPageAsync(pageIndex, pageSize,
                orderBy, orderDirection);
        }

        public Task<PaginatedList<TResult>> GetPageBySelectorAsync<TResult>(
            int pageIndex,
            int pageSize,
            Expression<Func<TEntity, TResult>> selector,
            Expression<Func<TEntity, object>> orderBy,
            OrderDirection orderDirection = OrderDirection.Ascending)
        {
            return _repository.GetPageBySelectorAsync<TResult>(pageIndex, pageSize,
                selector, orderBy, orderDirection);
        }

        public Task<PaginatedList<TEntity>> GetPageIncludingAsync(
            int pageIndex,
            int pageSize,
            Expression<Func<TEntity, object>> orderBy,
            OrderDirection orderDirection = OrderDirection.Ascending,
            params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return _repository.GetPageIncludingAsync(pageIndex, pageSize,
                orderBy, orderDirection, includeProperties);
        }

        public Task<PaginatedList<TEntity>> GetPageByFilterAsync(
            int pageIndex,
            int pageSize,
            Expression<Func<TEntity, object>> orderBy,
            OrderDirection orderDirection = OrderDirection.Ascending)
        {
            return _repository.GetPageByFilterAsync(pageIndex, pageSize, orderBy, orderDirection);
        }

        public Task<PaginatedList<TResult>> GetPageByFilterBySelectorAsync<TResult>(
            int pageIndex,
            int pageSize,
            Expression<Func<TEntity, TResult>> selector,
            Expression<Func<TEntity, object>> orderBy,
            OrderDirection orderDirection = OrderDirection.Ascending)
        {
            return _repository.GetPageByFilterBySelectorAsync(pageIndex, pageSize,
                selector, orderBy, orderDirection);
        }

        public Task<PaginatedList<TEntity>> GetPageByFilterIncludingAsync(
            int pageIndex,
            int pageSize,
            Expression<Func<TEntity, bool>> filter,
            Expression<Func<TEntity, object>> orderBy,
            OrderDirection orderDirection,
            params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return _repository.GetPageByFilterIncludingAsync(pageIndex, pageSize, filter, orderBy, orderDirection, includeProperties);
        }

        public Task<List<TEntity>> GetByFilterAsync(Expression<Func<TEntity, bool>> filter)
        {
            return _repository.GetByFilterAsync(filter);
        }

        public Task<List<TResult>> GetByFilterBySelectorAsync<TResult>(
            Expression<Func<TEntity, TResult>> selector,
            Expression<Func<TEntity, bool>> filter)
        {
            return _repository.GetByFilterBySelectorAsync(selector, filter);
        }

        public Task<List<TEntity>> GetByFilterIncludingAsync(
            Expression<Func<TEntity, bool>> filter,
            params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return _repository.GetByFilterIncludingAsync(filter, includeProperties);
        }

        public Task<List<TEntity>> GetByFilterAsync(
            Expression<Func<TEntity, bool>> filter,
            Expression<Func<TEntity, object>> orderBy,
            OrderDirection orderDirection = OrderDirection.Ascending)
        {
            return _repository.GetByFilterAsync(filter, orderBy, orderDirection);
        }

        public Task<List<TResult>> GetByFilterBySelectorAsync<TResult>(
            Expression<Func<TEntity, TResult>> selector,
            Expression<Func<TEntity, bool>> filter,
            Expression<Func<TEntity, object>> orderBy,
            OrderDirection orderDirection = OrderDirection.Ascending)
        {
            return _repository.GetByFilterBySelectorAsync(selector, filter, orderBy, orderDirection);
        }

        public Task<List<TEntity>> GetByFilterIncludingAsync(
            Expression<Func<TEntity, bool>> filter,
            Expression<Func<TEntity, object>> orderBy,
            OrderDirection orderDirection,
            params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return _repository.GetByFilterIncludingAsync(filter, orderBy,
                orderDirection, includeProperties);
        }



        public Task InsertAsync(TEntity entity)
        {
            _repository.Insert(entity);
            return UnitOfWork.SaveChangesAsync();
        }

        public Task UpdateAsync(TEntity entity)
        {
            _repository.Update(entity);
            return UnitOfWork.SaveChangesAsync();
        }

        public Task DeleteAsync(TEntity entity)
        {
            _repository.Delete(entity);
            return UnitOfWork.SaveChangesAsync();
        }


        public void Dispose()
        {
            UnitOfWork.Dispose();
        }



        public void BulkInsert(IList<TEntity> entities)
        {
            _repository.BulkInsert(entities);
        }

        public void BulkUpdate(IList<TEntity> entities)
        {
            _repository.BulkUpdate(entities);
        }


        public void BulkInsertOrUpdate(IList<TEntity> entities)
        {
            _repository.BulkInsertOrUpdate(entities);
        }

        public void BulkDelete(IList<TEntity> entities)
        {
            _repository.BulkDelete(entities);
        }

        public Task BulkInsertAsync(IList<TEntity> entities)
        {
            return _repository.BulkInsertAsync(entities);
        }

        public Task BulkUpdateAsync(IList<TEntity> entities)
        {
            return _repository.BulkUpdateAsync(entities);
        }

        public Task BulkInsertOrUpdateAsync(IList<TEntity> entities)
        {
            return _repository.BulkInsertOrUpdateAsync(entities);
        }

        public Task BulkDeleteAsync(IList<TEntity> entities)
        {
            return _repository.BulkDeleteAsync(entities);
        }

    }
}
