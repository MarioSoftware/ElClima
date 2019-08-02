using ElClima.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ElClima.Domain.Core.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        bool QueryTracking { get; set; }
        void SetRangeAsAdded(IEnumerable<object> entities);
        void SetRangeAsUpdated(IEnumerable<object> entities);
        void SetRangeAsDeleted(IEnumerable<object> entities);
        void SetAsAdded(object entity);
        void SetAsModified(object entity);
        void SetAsDeleted(object entity);
        void DetachEntry(object entity);
        void DetachAllEntries();
        int SaveChanges();
        IRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity;
        void BeginTransaction();
        int Commit();
        void Rollback();
        Task<int> SaveChangesAsync();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        Task<int> CommitAsync();
    }
}
