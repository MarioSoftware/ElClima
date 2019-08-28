using ElClima.Domain.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ElClima.DataAccess.ConcreteRepository
{
    public interface IEntitiesContext :IDisposable
    {
        DbSet<TEntity> Set<TEntity>() where TEntity : BaseEntity;
        void SetRangeAsAdded(IEnumerable<object> entities);
        void SetRangeAsUpdated(IEnumerable<object> entities);
        void SetRangeAsDeleted(IEnumerable<object> entities);
        void SetAsAdded(object entity); //where TEntity : BaseEntity;
        void SetAsModified(object entity); //where TEntity : BaseEntity;
        void SetAsDeleted(object entity); //where TEntity : BaseEntity;
        int SaveChanges();
        Task<int> SaveChangesAsync();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        void BeginTransaction();
        int Commit();
        void Rollback();
        Task<int> CommitAsync();
    }
}
