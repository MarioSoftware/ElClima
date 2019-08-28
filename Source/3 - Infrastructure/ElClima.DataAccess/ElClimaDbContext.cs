using ElClima.DataAccess.ConcreteRepository;
using ElClima.Domain.Core.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElClima.DataAccess
{
    public sealed class ElClimaDbContext : IdentityDbContext<ApplicationUser>, IEntitiesContext
    {
        private DbConnection _connection;
        private DbTransaction _transaction;
        private static readonly object Lock = new object();
        private static bool _databaseInitialized;

        public ElClimaDbContext(DbContextOptions options)
            : base(options)
        {

            //Database.Log = logger.Log;
            if (_databaseInitialized)
            {
                return;
            }
            lock (Lock)
            {
                if (!_databaseInitialized)
                {
                    //Database.EnsureCreated();
                    _databaseInitialized = true;
                }
            }
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            lock (ModelCreationLockObject)
            {
                if (_currentModel != null)
                {
                    optionsBuilder.UseModel(_currentModel);
                }
            }

            base.OnConfiguring(optionsBuilder);
        }

        private static IModel _currentModel;

        private static readonly object ModelCreationLockObject = new object();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            lock (ModelCreationLockObject)
            {

                base.OnModelCreating(modelBuilder);

                // Configuramos el mapping de las tablas
                //DataMapping.Comun.CompaniaSeguroConfigurator.Configure(modelBuilder);
                //DataMapping.Comun.CompaniaSeguroDatoContactoConfigurator.Configure(modelBuilder); 

                //DataMapping.Choferes.TipoDeudaConfigurator.Configure(modelBuilder);
                //DataMapping.Choferes.TipoChoferConfigurator.Configure(modelBuilder);
                

                foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
                {
                    relationship.DeleteBehavior = relationship.Properties.Any(prop => prop.IsNullable)
                        ? DeleteBehavior.ClientSetNull
                        : DeleteBehavior.Restrict;
                }

                _currentModel = modelBuilder.Model;
            }
        }



        public new DbSet<TEntity> Set<TEntity>() where TEntity : BaseEntity
        {
            return base.Set<TEntity>();
        }

        public void SetRangeAsAdded(IEnumerable<object> entities)
        {
            AddRange(entities);
        }

        public void SetRangeAsUpdated(IEnumerable<object> entities)
        {
            UpdateRange(entities);
        }

        public void SetRangeAsDeleted(IEnumerable<object> entities)
        {
            RemoveRange(entities);
        }


        public void SetAsAdded(object entity) //where TEntity : BaseEntity
        {
            UpdateEntityState(entity, EntityState.Added);
        }

        public void SetAsModified(object entity) //where TEntity : BaseEntity
        {
            UpdateEntityState(entity, EntityState.Modified);
        }

        public void SetAsDeleted(object entity) //where TEntity : BaseEntity
        {
            UpdateEntityState(entity, EntityState.Deleted);
        }

        public Task<int> SaveChangesAsync()
        {
            return base.SaveChangesAsync();
        }

        public void BeginTransaction()
        {
            if (Database.CurrentTransaction != null)
            {
                return;
            }

            _connection = Database.GetDbConnection();
            if (_connection.State == ConnectionState.Closed)
            {
                _connection.Open();
            }

            _transaction = _connection.BeginTransaction();
        }

        public int Commit()
        {
            var saveChanges = SaveChanges();
            _transaction.Commit();
            return saveChanges;
        }

        public void Rollback()
        {
            _transaction.Rollback();
        }

        public Task<int> CommitAsync()
        {
            var saveChangesAsync = SaveChangesAsync();
            _transaction.Commit();
            return saveChangesAsync;
        }

        private void UpdateEntityState(object entity, EntityState entityState) //where TEntity : BaseEntity
        {
            var entry = Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                Attach(entity);
            }

            entry.State = entityState;
        }


        public override void Dispose()
        {
            if (_connection != null && _connection.State == ConnectionState.Open)
            {
                _connection.Close();
            }
            _transaction?.Dispose();
            _connection?.Dispose();

            base.Dispose();
        }

    }
}
