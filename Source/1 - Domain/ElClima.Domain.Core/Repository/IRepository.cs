using ElClima.Domain.Core.Entities;
using ElClima.Domain.Core.Lists;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq; 
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ElClima.Domain.Core.Repository
{
    public interface  IRepository<TEntity> where TEntity : BaseEntity
    {
        DbSet<TEntity> GetEntitySet();  

        TEntity GetOne(int id);

        TResult GetOneBySelector<TResult>(int id,
            Expression<Func<TEntity, TResult>> selector);

        TEntity GetOneIncluding(
            int id,
            params Expression<Func<TEntity, object>>[] includeProperties);

        TEntity GetOneByQuery(IQueryable<TEntity> query);


        List<TEntity> GetAll();

        List<TResult> GetAllBySelector<TResult>(Expression<Func<TEntity, TResult>> selector);

        List<TEntity> GetAllIncluding(
            params Expression<Func<TEntity, object>>[] includeProperties);


        List<TEntity> GetAll(
            Expression<Func<TEntity, object>> orderBy,
            OrderDirection orderDirection = OrderDirection.Ascending);

        List<TResult> GetAllBySelector<TResult>(
            Expression<Func<TEntity, TResult>> selector,
            Expression<Func<TEntity, object>> orderBy,
            OrderDirection orderDirection = OrderDirection.Ascending);

        List<TEntity> GetAllIncluding(
            Expression<Func<TEntity, object>> orderBy,
            OrderDirection orderDirection = OrderDirection.Ascending,
            params Expression<Func<TEntity, object>>[] includeProperties);


        PaginatedList<TEntity> GetPage(int pageIndex, int pageSize);

        PaginatedList<TResult> GetPageBySelector<TResult>(
            int pageIndex,
            int pageSize,
            Expression<Func<TEntity, TResult>> selector);

        PaginatedList<TEntity> GetPageIncluding(
            int pageIndex,
            int pageSize,
            params Expression<Func<TEntity, object>>[] includeProperties);


        PaginatedList<TEntity> GetPage(
            int pageIndex,
            int pageSize,
            Expression<Func<TEntity, object>> orderBy,
            OrderDirection orderDirection = OrderDirection.Ascending);

        PaginatedList<TResult> GetPageBySelector<TResult>(
            int pageIndex,
            int pageSize,
            Expression<Func<TEntity, TResult>> selector,
            Expression<Func<TEntity, object>> orderBy,
            OrderDirection orderDirection = OrderDirection.Ascending);

        PaginatedList<TEntity> GetPageIncluding(
            int pageIndex,
            int pageSize,
            Expression<Func<TEntity, object>> orderBy,
            OrderDirection orderDirection = OrderDirection.Ascending,
            params Expression<Func<TEntity, object>>[] includeProperties);

        PaginatedList<TResult> GetPageBySelectorIncluding<TResult>(
            int pageIndex,
            int pageSize,
            Expression<Func<TEntity, TResult>> selector,
            Expression<Func<TEntity, object>> orderBy,
            OrderDirection orderDirection = OrderDirection.Ascending,
            params Expression<Func<TEntity, object>>[] includeProperties);

        PaginatedList<TEntity> GetPageByFilter(
            int pageIndex,
            int pageSize,
            Expression<Func<TEntity, bool>> filter,
            Expression<Func<TEntity, object>> orderBy,
            OrderDirection orderDirection);

        PaginatedList<TResult> GetPageByFilterBySelector<TResult>(
            int pageIndex,
            int pageSize,
            Expression<Func<TEntity, TResult>> selector,
            Expression<Func<TEntity, bool>> filter,
            Expression<Func<TEntity, object>> orderBy,
            OrderDirection orderDirection);

        PaginatedList<TResult> GetPageByFilterBySelectorIncluding<TResult>(
            int pageIndex,
            int pageSize,
            Expression<Func<TEntity, TResult>> selector,
            Expression<Func<TEntity, bool>> filter,
            Expression<Func<TEntity, object>> orderBy,
            OrderDirection orderDirection,
            params Expression<Func<TEntity, object>>[] includeProperties);

        PaginatedList<TEntity> GetPageByFilterIncluding(
            int pageIndex,
            int pageSize,
            Expression<Func<TEntity, bool>> filter,
            Expression<Func<TEntity, object>> orderBy,
            OrderDirection orderDirection,
            params Expression<Func<TEntity, object>>[] includeProperties);


        List<TEntity> GetByFilter(Expression<Func<TEntity, bool>> filter);

        List<TResult> GetByFilterBySelector<TResult>(
            Expression<Func<TEntity, TResult>> selector,
            Expression<Func<TEntity, bool>> filter);

        List<TEntity> GetByFilterIncluding(
            Expression<Func<TEntity, bool>> filter,
            params Expression<Func<TEntity, object>>[] includeProperties);


        List<TEntity> GetByFilter(
            Expression<Func<TEntity, bool>> filter,
            Expression<Func<TEntity, object>> orderBy,
            OrderDirection orderDirection);

        List<TResult> GetByFilterBySelector<TResult>(
            Expression<Func<TEntity, TResult>> selector,
            Expression<Func<TEntity, bool>> filter,
            Expression<Func<TEntity, object>> orderBy,
            OrderDirection orderDirection);

        List<TResult> GetByFilterBySelectorIncluding<TResult>(
            Expression<Func<TEntity, TResult>> selector,
            Expression<Func<TEntity, bool>> filter,
            Expression<Func<TEntity, object>> orderBy,
            OrderDirection orderDirection,
            params Expression<Func<TEntity, object>>[] includeProperties);

        List<TEntity> GetByFilterIncluding(
            Expression<Func<TEntity, bool>> filter,
            Expression<Func<TEntity, object>> orderBy,
            OrderDirection orderDirection,
            params Expression<Func<TEntity, object>>[] includeProperties);


        void Insert(TEntity entity);

        void Update(TEntity entity);

        void Delete(TEntity entity);



        Task<TEntity> GetOneAsync(int id);

        Task<TResult> GetOneBySelectorAsync<TResult>(
            int id,
            Expression<Func<TEntity, TResult>> selector);

        Task<TEntity> GetOneIncludingAsync(
            int id,
            params Expression<Func<TEntity, object>>[] includeProperties);


        Task<List<TEntity>> GetAllAsync();

        Task<List<TResult>> GetAllBySelectorAsync<TResult>(
            Expression<Func<TEntity, TResult>> selector);

        Task<List<TEntity>> GetAllIncludingAsync(
            params Expression<Func<TEntity, object>>[] includeProperties);


        Task<PaginatedList<TEntity>> GetPageAsync(int pageIndex, int pageSize);

        Task<PaginatedList<TResult>> GetPageBySelectorAsync<TResult>(
            int pageIndex,
            int pageSize,
            Expression<Func<TEntity, TResult>> selector);

        Task<PaginatedList<TEntity>> GetPageIncludingAsync(
            int pageIndex,
            int pageSize,
            params Expression<Func<TEntity, object>>[] includeProperties);


        Task<PaginatedList<TEntity>> GetPageAsync(
            int pageIndex,
            int pageSize,
            Expression<Func<TEntity, object>> orderBy,
            OrderDirection orderDirection = OrderDirection.Ascending);

        Task<PaginatedList<TResult>> GetPageBySelectorAsync<TResult>(
            int pageIndex,
            int pageSize,
            Expression<Func<TEntity, TResult>> selector,
            Expression<Func<TEntity, object>> orderBy,
            OrderDirection orderDirection = OrderDirection.Ascending);

        Task<PaginatedList<TEntity>> GetPageIncludingAsync(
            int pageIndex,
            int pageSize,
            Expression<Func<TEntity, object>> orderBy,
            OrderDirection orderDirection = OrderDirection.Ascending,
            params Expression<Func<TEntity, object>>[] includeProperties);


        Task<PaginatedList<TEntity>> GetPageByFilterAsync(
            int pageIndex,
            int pageSize,
            Expression<Func<TEntity, object>> orderBy,
            OrderDirection orderDirection = OrderDirection.Ascending);

        Task<PaginatedList<TResult>> GetPageByFilterBySelectorAsync<TResult>(
            int pageIndex,
            int pageSize,
            Expression<Func<TEntity, TResult>> selector,
            Expression<Func<TEntity, object>> orderBy,
            OrderDirection orderDirection = OrderDirection.Ascending);

        Task<PaginatedList<TEntity>> GetPageByFilterIncludingAsync(
            int pageIndex,
            int pageSize,
            Expression<Func<TEntity, bool>> filter,
            Expression<Func<TEntity, object>> orderBy,
            OrderDirection orderDirection,
            params Expression<Func<TEntity, object>>[] includeProperties);


        Task<List<TEntity>> GetByFilterAsync(
            Expression<Func<TEntity, bool>> filter);

        Task<List<TResult>> GetByFilterBySelectorAsync<TResult>(
            Expression<Func<TEntity, TResult>> selector,
            Expression<Func<TEntity, bool>> filter);

        Task<List<TEntity>> GetByFilterIncludingAsync(
            Expression<Func<TEntity, bool>> filter,
            params Expression<Func<TEntity, object>>[] includeProperties);


        Task<List<TEntity>> GetByFilterAsync(
            Expression<Func<TEntity, bool>> filter,
            Expression<Func<TEntity, object>> orderBy,
            OrderDirection orderDirection = OrderDirection.Ascending);

        Task<List<TResult>> GetByFilterBySelectorAsync<TResult>(
            Expression<Func<TEntity, TResult>> selector,
            Expression<Func<TEntity, bool>> filter,
            Expression<Func<TEntity, object>> orderBy,
            OrderDirection orderDirection = OrderDirection.Ascending);

        Task<List<TEntity>> GetByFilterIncludingAsync(
            Expression<Func<TEntity, bool>> filter,
            Expression<Func<TEntity, object>> orderBy,
            OrderDirection orderDirection,
            params Expression<Func<TEntity, object>>[] includeProperties);


        void BulkInsert(IList<TEntity> entities);

        void BulkUpdate(IList<TEntity> entities);

        void BulkInsertOrUpdate(IList<TEntity> entities);

        void BulkDelete(IList<TEntity> entities);


        Task BulkInsertAsync(IList<TEntity> entities);

        Task BulkUpdateAsync(IList<TEntity> entities);

        Task BulkInsertOrUpdateAsync(IList<TEntity> entities);

        Task BulkDeleteAsync(IList<TEntity> entities);
    }
}
