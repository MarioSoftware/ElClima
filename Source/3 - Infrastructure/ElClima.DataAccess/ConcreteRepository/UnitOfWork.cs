using ElClima.Domain.Core.Entities;
using ElClima.Domain.Core.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ElClima.DataAccess.ConcreteRepository
{
    public sealed class UnitOfWork : IUnitOfWork
    {

        private readonly IEntitiesContext _context;
         
        public UnitOfWork(IEntitiesContext context)
        {
            _context = context;
            QueryTracking = true;
        }
        public bool QueryTracking
        {
            get => ((ElClimaDbContext)_context).ChangeTracker.QueryTrackingBehavior ==
                   QueryTrackingBehavior.TrackAll;
            set =>
                ((ElClimaDbContext)_context).ChangeTracker.QueryTrackingBehavior = value
                ? QueryTrackingBehavior.TrackAll
                : QueryTrackingBehavior.NoTracking;
        }

        public void SetRangeAsAdded(IEnumerable<object> entities)
        {
            _context.SetRangeAsAdded(entities);
        }

        public void SetRangeAsUpdated(IEnumerable<object> entities)
        {
            _context.SetRangeAsUpdated(entities);
        }

        public void SetRangeAsDeleted(IEnumerable<object> entities)
        {
            _context.SetRangeAsDeleted(entities);
        }

        public void SetAsAdded(object entity)
        {
            _context.SetAsAdded(entity);
        }

        public void SetAsModified(object entity)
        {
            _context.SetAsModified(entity);
        }

        public void SetAsDeleted(object entity)
        {
            _context.SetAsDeleted(entity);
        }

        public void DetachEntry(object entity)
        {
            ((ElClimaDbContext)_context).Entry(entity).State = EntityState.Detached;
        }

        public void DetachAllEntries()
        {
            var changedEntriesCopy = ((ElClimaDbContext)_context).ChangeTracker.Entries().Where(
                    e => e.State == EntityState.Added ||
                         e.State == EntityState.Modified ||
                         e.State == EntityState.Deleted)
                .ToList();

            foreach (var entity in changedEntriesCopy)
            {
                ((ElClimaDbContext)_context).Entry(entity.Entity).State = EntityState.Detached;
            }
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public IRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity
        {

            var repositoryType = typeof(EntityRepository<>);
            return (IRepository<TEntity>)Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)), _context);


            //if (_repositories == null)
            //{
            //    _repositories = new Hashtable();
            //}

            //var type = typeof(TEntity).Name;
            //if (!_repositories.ContainsKey(type))
            //{
            //    var repositoryType = typeof(EntityRepository<>);
            //    _repositories.Add(type,
            //        Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)), _context));
            //}

            //return (IRepository<TEntity>)_repositories[type];
        }

        public Task<int> SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            return _context.SaveChangesAsync(cancellationToken);
        }

        public void BeginTransaction()
        {
            _context.BeginTransaction();
        }

        public int Commit()
        {
            return _context.Commit();
        }

        public void Rollback()
        {
            _context.Rollback();
        }

        public Task<int> CommitAsync()
        {
            return _context.CommitAsync();
        }


        //public void Dispose()
        //{
        //    _context.Dispose();
        //    //Dispose(true);
        //    //GC.SuppressFinalize(this);
        //}

        //private static int _destructorCounter;


        //public void Dispose(bool disposing)
        //{
        //    if (!_disposed && disposing)
        //    {
        //        _context.Dispose();
        //        //if (_repositories?.Values != null)
        //        //{
        //        //    foreach (IDisposable repository in _repositories.Values)
        //        //    {
        //        //        repository.Dispose(); // dispose all repositries
        //        //    }
        //        //}
        //    }

        //    //_destructorCounter++;
        //    //if (_destructorCounter > 1000)
        //    //{
        //    //    GC.Collect();
        //    //}


        //    _disposed = true;

        //}
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
