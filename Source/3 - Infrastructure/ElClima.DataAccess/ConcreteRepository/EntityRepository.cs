using EFCore.BulkExtensions;
using ElClima.Domain.Core.Entities;
using ElClima.Domain.Core.Extensions;
using ElClima.Domain.Core.Lists;
using ElClima.Domain.Core.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ElClima.DataAccess.ConcreteRepository
{
    public sealed class EntityRepository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly IEntitiesContext _context;
        private readonly DbSet<TEntity> _dbEntitySet;

        public EntityRepository(IEntitiesContext context)
        {
            
            _context = context;
            _dbEntitySet = _context.Set<TEntity>();
        }

        public DbSet<TEntity> GetEntitySet()
        {
            return _dbEntitySet;
        }

        public TEntity GetOne(int id)
        {
            return _dbEntitySet.FirstOrDefault(t => t.id == id);
        }

        public TResult GetOneBySelector<TResult>(int id,
            Expression<Func<TEntity, TResult>> selector)
        {
            return _dbEntitySet.Where(t => t.id == id).Select(selector).FirstOrDefault();
        }

        public TEntity GetOneIncluding(int id,
            params Expression<Func<TEntity, object>>[] includeProperties)
        {
            var entities = IncludeProperties(includeProperties);
            return entities.FirstOrDefault(x => x.id == id);
        }

        public TEntity GetOneByQuery(
            IQueryable<TEntity> query)
        {
            return query.FirstOrDefault();
        }


        public List<TEntity> GetAll()
        {
            return _dbEntitySet.ToList();
        }

        public List<TResult> GetAllBySelector<TResult>(Expression<Func<TEntity, TResult>> selector)
        {
            return _dbEntitySet.Select(selector).ToList();
        }

        public List<TEntity> GetAllIncluding(
            params Expression<Func<TEntity, object>>[] includeProperties)
        {
            var entities = IncludeProperties(includeProperties);
            return entities.ToList();
        }


        public List<TEntity> GetAll(
            Expression<Func<TEntity, object>> orderBy,
            OrderDirection orderDirection = OrderDirection.Ascending)
        {
            return FilterQuery(null, orderBy, orderDirection, null).ToList();
        }

        public List<TResult> GetAllBySelector<TResult>(
            Expression<Func<TEntity, TResult>> selector,
            Expression<Func<TEntity, object>> orderBy,
            OrderDirection orderDirection = OrderDirection.Ascending)
        {
            return FilterQueryWithSelector<TResult>(selector, null, orderBy, orderDirection).ToList();
        }

        public List<TEntity> GetAllIncluding(
            Expression<Func<TEntity, object>> orderBy,
            OrderDirection orderDirection = OrderDirection.Ascending,
            params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return FilterQuery(null, orderBy, orderDirection, includeProperties).ToList();
        }


        public PaginatedList<TEntity> GetPage(int pageIndex, int pageSize)
        {
            return GetPage(pageIndex, pageSize, null);
        }

        public PaginatedList<TEntity> GetPageIncluding(
            int pageIndex,
            int pageSize,
            params Expression<Func<TEntity, object>>[] includeProperties)
        {
            if (pageIndex < 1)
            {
                pageIndex = 1;
            }
            var entities = IncludeProperties(includeProperties).AsNoTracking();
            var total = entities.Count();
            entities = entities.Paginate(pageIndex, pageSize);
            return entities.ToPaginatedList(pageIndex, pageSize, total);
        }


        public PaginatedList<TEntity> GetPage(
            int pageIndex,
            int pageSize,
            Expression<Func<TEntity, object>> orderBy,
            OrderDirection orderDirection = OrderDirection.Ascending)
        {
            return GetPageByFilter(pageIndex, pageSize, null, orderBy, orderDirection);
        }

        public PaginatedList<TResult> GetPageBySelector<TResult>(
            int pageIndex,
            int pageSize,
            Expression<Func<TEntity, TResult>> selector)
        {
            if (pageIndex < 1)
            {
                pageIndex = 1;
            }

            var entities = _dbEntitySet.AsNoTracking().Select(selector);
            var total = entities.Count();
            entities = entities.Paginate(pageIndex, pageSize);
            return entities.ToPaginatedList(pageIndex, pageSize, total);
        }

        public PaginatedList<TResult> GetPageBySelector<TResult>(
            int pageIndex,
            int pageSize,
            Expression<Func<TEntity, TResult>> selector,
            Expression<Func<TEntity, object>> orderBy,
            OrderDirection orderDirection = OrderDirection.Ascending)

        {
            var entities = FilterQuery(null, orderBy, orderDirection, null).AsNoTracking()
                .Select(selector);
            var total = entities.Count();
            entities = entities.Paginate(pageIndex, pageSize);
            return entities.ToPaginatedList(pageIndex, pageSize, total);
        }


        public PaginatedList<TEntity> GetPageIncluding(
            int pageIndex,
            int pageSize,
            Expression<Func<TEntity, object>> orderBy,
            OrderDirection orderDirection = OrderDirection.Ascending,
            params Expression<Func<TEntity, object>>[] includeProperties)
        {
            if (pageIndex < 1)
            {
                pageIndex = 1;
            }
            var entities = FilterQuery(null, orderBy, orderDirection, includeProperties).AsNoTracking();
            var total = entities.Count();
            entities = entities.Paginate(pageIndex, pageSize);
            return entities.AsNoTracking().ToPaginatedList(pageIndex, pageSize, total);
        }

        public PaginatedList<TResult> GetPageBySelectorIncluding<TResult>(int pageIndex, int pageSize, Expression<Func<TEntity, TResult>> selector, Expression<Func<TEntity, object>> orderBy,
            OrderDirection orderDirection = OrderDirection.Ascending, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            if (pageIndex < 1)
            {
                pageIndex = 1;
            }
            var entities = FilterQuery(null, orderBy, orderDirection, includeProperties).AsNoTracking()
                .Select(selector);
            var total = entities.Count();
            entities = entities.Paginate(pageIndex, pageSize);
            return entities.ToPaginatedList(pageIndex, pageSize, total);
        }


        public PaginatedList<TEntity> GetPageByFilter(
            int pageIndex,
            int pageSize,
            Expression<Func<TEntity, bool>> filter,
            Expression<Func<TEntity, object>> orderBy,
            OrderDirection orderDirection)
        {
            if (pageIndex < 1)
            {
                pageIndex = 1;
            }
            var entities = FilterQuery(filter, orderBy, orderDirection, null).AsNoTracking();
            var total = entities.Count();
            entities = entities.Paginate(pageIndex, pageSize);
            return entities.AsNoTracking().ToPaginatedList(pageIndex, pageSize, total);
        }

        public PaginatedList<TResult> GetPageByFilterBySelector<TResult>(
            int pageIndex,
            int pageSize,
            Expression<Func<TEntity, TResult>> selector,
            Expression<Func<TEntity, bool>> filter,
            Expression<Func<TEntity, object>> orderBy,
            OrderDirection orderDirection)
        {
            if (pageIndex < 1)
            {
                pageIndex = 1;
            }
            var entities = FilterQuery(filter, orderBy, orderDirection, null).AsNoTracking()
                .Select(selector);
            var total = entities.Count();
            entities = entities.Paginate(pageIndex, pageSize);
            return entities.ToPaginatedList(pageIndex, pageSize, total);
        }

        public PaginatedList<TResult> GetPageByFilterBySelectorIncluding<TResult>(int pageIndex, int pageSize,
            Expression<Func<TEntity, TResult>> selector,
            Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, object>> orderBy,
            OrderDirection orderDirection, params Expression<Func<TEntity, object>>[] includeProperties)
        {

            if (pageIndex < 1)
            {
                pageIndex = 1;
            }
            var entities = FilterQuery(filter, orderBy, orderDirection, includeProperties).AsNoTracking()
                .Select(selector);
            var total = entities.Count();
            entities = entities.Paginate(pageIndex, pageSize);
            return entities.ToPaginatedList(pageIndex, pageSize, total);
        }


        public PaginatedList<TEntity> GetPageByFilterIncluding(
            int pageIndex,
            int pageSize,
            Expression<Func<TEntity, bool>> filter,
            Expression<Func<TEntity, object>> orderBy,
            OrderDirection orderDirection,
            params Expression<Func<TEntity, object>>[] includeProperties)
        {
            if (pageIndex < 1)
            {
                pageIndex = 1;
            }
            var entities = FilterQuery(filter, orderBy, orderDirection, includeProperties).AsNoTracking();
            var total = entities.Count();
            entities = entities.Paginate(pageIndex, pageSize);
            return entities.ToPaginatedList(pageIndex, pageSize, total);
        }


        public List<TEntity> GetByFilter(Expression<Func<TEntity, bool>> filter)
        {
            return _dbEntitySet.Where(filter).ToList();
        }

        public List<TResult> GetByFilterBySelector<TResult>(
            Expression<Func<TEntity, TResult>> selector,
            Expression<Func<TEntity, bool>> filter)
        {
            return _dbEntitySet.Where(filter).Select(selector).ToList();
        }

        public List<TEntity> GetByFilterIncluding(
            Expression<Func<TEntity, bool>> filter,
            params Expression<Func<TEntity, object>>[] includeProperties)
        {
            var entities = IncludeProperties(includeProperties);
            return entities.Where(filter).ToList();
        }


        public List<TEntity> GetByFilter(
            Expression<Func<TEntity, bool>> filter,
            Expression<Func<TEntity, object>> orderBy,
            OrderDirection orderDirection)
        {
            var entities = FilterQuery(filter, orderBy, orderDirection, null);
            return entities.ToList();
        }

        public List<TResult> GetByFilterBySelector<TResult>(
            Expression<Func<TEntity, TResult>> selector,
            Expression<Func<TEntity, bool>> filter,
            Expression<Func<TEntity, object>> orderBy,
            OrderDirection orderDirection)
        {
            var entities = FilterQuery(filter, orderBy, orderDirection, null);
            return entities.Select(selector).ToList();
        }

        public List<TResult> GetByFilterBySelectorIncluding<TResult>(
            Expression<Func<TEntity, TResult>> selector,
            Expression<Func<TEntity, bool>> filter,
            Expression<Func<TEntity, object>> orderBy,
            OrderDirection orderDirection, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            var entities = FilterQuery(filter, orderBy, orderDirection, includeProperties);
            return entities.Select(selector).ToList();
        }

        public List<TEntity> GetByFilterIncluding(
            Expression<Func<TEntity, bool>> filter,
            Expression<Func<TEntity, object>> orderBy,
            OrderDirection orderDirection,
            params Expression<Func<TEntity, object>>[] includeProperties)
        {
            var entities = FilterQuery(filter, orderBy, orderDirection, includeProperties);
            return entities.ToList();
        }


        public void Insert(TEntity entity)
        {
            //_recordLogger.LogRecordInsertion(entity);
            _context.SetAsAdded(entity);
        }

        public void Update(TEntity entity)
        {
            //_recordLogger.LogRecordUpdate(entity);
            _context.SetAsModified(entity);
        }

        public void Delete(TEntity entity)
        {
            //_recordLogger.LogRecordDeletion(entity);
            _context.SetAsDeleted(entity);
        }


        public Task<TEntity> GetOneAsync(int id)
        {
            return _dbEntitySet.FirstOrDefaultAsync(entity => entity.id == id);
        }

        public Task<TResult> GetOneBySelectorAsync<TResult>(
            int id,
            Expression<Func<TEntity, TResult>> selector)
        {
            return _dbEntitySet.Where(entity => entity.id == id)
                .Select(selector).FirstOrDefaultAsync();
        }

        public Task<TEntity> GetOneIncludingAsync(
            int id,
            params Expression<Func<TEntity, object>>[] includeProperties)
        {
            var entities = IncludeProperties(includeProperties);
            return entities.FirstOrDefaultAsync(x => x.id == id);
        }


        public Task<List<TEntity>> GetAllAsync()
        {
            return _dbEntitySet.ToListAsync();
        }

        public Task<List<TResult>> GetAllBySelectorAsync<TResult>(
            Expression<Func<TEntity, TResult>> selector)
        {
            return _dbEntitySet.Select(selector).ToListAsync();
        }

        public Task<List<TEntity>> GetAllIncludingAsync(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            var entities = IncludeProperties(includeProperties);
            return entities.ToListAsync();
        }


        public async Task<PaginatedList<TEntity>> GetPageAsync(int pageIndex, int pageSize)
        {
            var entities = _dbEntitySet.Paginate(pageIndex, pageSize).AsNoTracking();
            var total = await entities.CountAsync();
            var list = await entities.ToListAsync();
            return list.ToPaginatedList(pageIndex, pageSize, total);
        }

        public async Task<PaginatedList<TResult>> GetPageBySelectorAsync<TResult>(
            int pageIndex,
            int pageSize,
            Expression<Func<TEntity, TResult>> selector)
        {
            var entities = _dbEntitySet.AsNoTracking().Select(selector).Paginate(pageIndex, pageSize);
            var total = await entities.CountAsync();
            var list = await entities.ToListAsync();
            return list.ToPaginatedList(pageIndex, pageSize, total);
        }

        public async Task<PaginatedList<TEntity>> GetPageIncludingAsync(
            int pageIndex,
            int pageSize,
            params Expression<Func<TEntity, object>>[] includeProperties)
        {
            if (pageIndex < 1)
            {
                pageIndex = 1;
            }
            var entities = IncludeProperties(includeProperties).AsNoTracking();
            var total = await entities.CountAsync();
            entities = entities.Paginate(pageIndex, pageSize);
            var list = await entities.ToListAsync();
            return list.ToPaginatedList(pageIndex, pageSize, total);
        }


        public Task<PaginatedList<TEntity>> GetPageAsync(
            int pageIndex,
            int pageSize,
            Expression<Func<TEntity, object>> orderBy,
            OrderDirection orderDirection = OrderDirection.Ascending)
        {
            return GetPageByFilterAsync(pageIndex, pageSize, orderBy,
                orderDirection);
        }

        public async Task<PaginatedList<TResult>> GetPageBySelectorAsync<TResult>(
            int pageIndex,
            int pageSize,
            Expression<Func<TEntity, TResult>> selector,
            Expression<Func<TEntity, object>> orderBy,
            OrderDirection orderDirection = OrderDirection.Ascending)
        {
            if (pageIndex < 1)
            {
                pageIndex = 1;
            }
            var entities = FilterQuery(null, orderBy, orderDirection, null).AsNoTracking()
                .Select(selector);
            var total = await entities.CountAsync();
            entities = entities.Paginate(pageIndex, pageSize);
            var list = await entities.ToListAsync();
            return list.ToPaginatedList(pageIndex, pageSize, total);
        }

        public Task<PaginatedList<TEntity>> GetPageIncludingAsync(
            int pageIndex,
            int pageSize,
            Expression<Func<TEntity, object>> orderBy,
            OrderDirection orderDirection = OrderDirection.Ascending,
            params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return GetPageByFilterIncludingAsync(pageIndex, pageSize, null,
                orderBy, orderDirection, includeProperties);
        }


        public Task<PaginatedList<TEntity>> GetPageByFilterAsync(
            int pageIndex,
            int pageSize,
            Expression<Func<TEntity, object>> orderBy,
            OrderDirection orderDirection = OrderDirection.Ascending)
        {
            return GetPageByFilterIncludingAsync(pageIndex, pageSize,
                null, orderBy, orderDirection);
        }

        public async Task<PaginatedList<TResult>> GetPageByFilterBySelectorAsync<TResult>(
            int pageIndex,
            int pageSize,
            Expression<Func<TEntity, TResult>> selector,
            Expression<Func<TEntity, object>> orderBy,
            OrderDirection orderDirection = OrderDirection.Ascending)
        {
            if (pageIndex < 1)
            {
                pageIndex = 1;
            }
            var entities = FilterQuery(null, orderBy, orderDirection, null).AsNoTracking()
                .Select(selector);
            var total = await entities.CountAsync();
            entities = entities.Paginate(pageIndex, pageSize);
            var list = await entities.ToListAsync();
            return list.ToPaginatedList(pageIndex, pageSize, total);
        }

        public async Task<PaginatedList<TEntity>> GetPageByFilterIncludingAsync(
            int pageIndex,
            int pageSize,
            Expression<Func<TEntity, bool>> filter,
            Expression<Func<TEntity, object>> orderBy,
            OrderDirection orderDirection,
            params Expression<Func<TEntity, object>>[] includeProperties)
        {
            if (pageIndex < 1)
            {
                pageIndex = 1;
            }
            var entities = FilterQuery(filter, orderBy, orderDirection, includeProperties).AsNoTracking();
            var total = await entities.CountAsync();
            entities = entities.Paginate(pageIndex, pageSize);
            var list = await entities.ToListAsync();
            return list.ToPaginatedList(pageIndex, pageSize, total);
        }


        public Task<List<TEntity>> GetByFilterAsync(Expression<Func<TEntity, bool>> filter)
        {
            return _dbEntitySet.Where(filter).ToListAsync();
        }

        public Task<List<TResult>> GetByFilterBySelectorAsync<TResult>(
            Expression<Func<TEntity, TResult>> selector,
            Expression<Func<TEntity, bool>> filter)
        {
            return _dbEntitySet.Where(filter).Select(selector).ToListAsync();
        }

        public Task<List<TEntity>> GetByFilterIncludingAsync(
            Expression<Func<TEntity, bool>> filter,
            params Expression<Func<TEntity, object>>[] includeProperties)
        {
            var entities = IncludeProperties(includeProperties);
            return entities.Where(filter).ToListAsync();
        }



        public Task<List<TEntity>> GetByFilterAsync(
            Expression<Func<TEntity, bool>> filter,
            Expression<Func<TEntity, object>> orderBy,
            OrderDirection orderDirection = OrderDirection.Ascending)
        {
            return GetByFilterIncludingAsync(
                filter, orderBy, orderDirection);
        }

        public Task<List<TResult>> GetByFilterBySelectorAsync<TResult>(
            Expression<Func<TEntity, TResult>> selector,
            Expression<Func<TEntity, bool>> filter,
            Expression<Func<TEntity, object>> orderBy,
            OrderDirection orderDirection = OrderDirection.Ascending)
        {
            var entities = FilterQuery(filter, orderBy, orderDirection, null);
            return entities.Select(selector).ToListAsync();
        }

        public Task<List<TEntity>> GetByFilterIncludingAsync(
            Expression<Func<TEntity, bool>> filter,
            Expression<Func<TEntity, object>> orderBy,
            OrderDirection orderDirection,
            params Expression<Func<TEntity, object>>[] includeProperties)
        {
            var entities = FilterQuery(filter, orderBy, orderDirection, includeProperties);
            return entities.ToListAsync();
        }

        private IQueryable<TResult> FilterQueryWithSelector<TResult>(
            Expression<Func<TEntity, TResult>> selector,
            Expression<Func<TEntity, bool>> filter,
            Expression<Func<TEntity, object>> orderBy,
            OrderDirection orderDirection)
        {
            IQueryable<TEntity> entities = _dbEntitySet;
            entities = (filter != null) ? entities.Where(filter) : entities;
            if (orderBy != null)
            {
                entities = (orderDirection == OrderDirection.Ascending)
                    ? entities.OrderBy(orderBy)
                    : entities.OrderByDescending(orderBy);
            }
            return entities.Select(selector);
        }

        private IQueryable<TEntity> FilterQuery(
            Expression<Func<TEntity, bool>> filter,
            Expression<Func<TEntity, object>> orderBy,
            OrderDirection orderDirection,
            Expression<Func<TEntity, object>>[] includeProperties)
        {
            var entities = IncludeProperties(includeProperties);
            entities = (filter != null) ? entities.Where(filter) : entities;
            if (orderBy != null)
            {
                entities = (orderDirection == OrderDirection.Ascending)
                    ? entities.OrderBy(orderBy)
                    : entities.OrderByDescending(orderBy);
            }
            return entities;
        }

        private IQueryable<TEntity> IncludeProperties(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> entities = _dbEntitySet;
            if (includeProperties == null)
            {
                return entities;
            }
            foreach (var includeProperty in includeProperties)
            {
                entities = entities.Include(includeProperty);
            }
            return entities;
        }





        public void BulkInsert(IList<TEntity> entities)
        {
            ((DbContext)_context).BulkInsert(entities);
        }

        public void BulkUpdate(IList<TEntity> entities)
        {
            ((DbContext)_context).BulkUpdate(entities);
        }

        public void BulkInsertOrUpdate(IList<TEntity> entities)
        {
            ((DbContext)_context).BulkInsertOrUpdate(entities);
        }

        public void BulkDelete(IList<TEntity> entities)
        {
            ((DbContext)_context).BulkDelete(entities);
        }



        public Task BulkInsertAsync(IList<TEntity> entities)
        {
            return ((DbContext)_context).BulkInsertAsync(entities);
        }

        public Task BulkUpdateAsync(IList<TEntity> entities)
        {
            return ((DbContext)_context).BulkUpdateAsync(entities);
        }

        public Task BulkInsertOrUpdateAsync(IList<TEntity> entities)
        {
            return ((DbContext)_context).BulkInsertOrUpdateAsync(entities);
        }

        public Task BulkDeleteAsync(IList<TEntity> entities)
        {
            return ((DbContext)_context).BulkDeleteAsync(entities);
        }



        //public void Dispose()
        //{
        //    Dispose(true);
        //    GC.SuppressFinalize(this);
        //}

        //private void Dispose(bool disposing)
        //{
        //    if (!_disposed && disposing)
        //    {
        //        _context.Dispose();
        //    }
        //    _disposed = true;
        //}
    }
}
