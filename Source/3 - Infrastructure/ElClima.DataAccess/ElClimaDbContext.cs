using ElClima.DataAccess.ConcreteRepository;
using ElClima.DataAccess.DataMapping.Comun;
using ElClima.DataAccess.DataMapping.Social.Entidades;
using ElClima.DataAccess.DataMapping.Social.Reporte.Historias;
using ElClima.DataAccess.DataMapping.Social.Reporte.Perdidas;
using ElClima.DataAccess.DataMapping.Social.Reporte.Robo;
using ElClima.DataAccess.DataMapping.Social.Sujetos;
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
        private static readonly object Lock = new object();
        private static bool _databaseInitialized;

        private static IModel _currentModel;

        private static readonly object ModelCreationLockObject = new object();

        private DbConnection _connection;
        private DbTransaction _transaction;

        public ElClimaDbContext(DbContextOptions options)
            : base(options)
        {
            //Database.Log = logger.Log;
            if (_databaseInitialized) return;
            lock (Lock)
            {
                if (!_databaseInitialized) _databaseInitialized = true;
            }
        }

        public new DbSet<TEntity> Set<TEntity>() where TEntity : BaseEntity
        {
            return base.Set<TEntity>();
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


        public Task<int> SaveChangesAsync()
        {
            return base.SaveChangesAsync();
        }

        public void BeginTransaction()
        {
            if (Database.CurrentTransaction != null) return;

            _connection = Database.GetDbConnection();
            if (_connection.State == ConnectionState.Closed) _connection.Open();

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

        //private DbEntityEntry GetDbEntityEntrySafely<TEntity>(TEntity entity) where TEntity : BaseEntity
        //{
        //    var dbEntityEntry = Entry<TEntity>(entity);
        //    if (dbEntityEntry.State == EntityState.Detached)
        //    {
        //        Set<TEntity>().Attach(entity);
        //    }
        //    return dbEntityEntry;
        //}

        public override void Dispose()
        {
            if (_connection != null && _connection.State == ConnectionState.Open) _connection.Close();
            _transaction?.Dispose();
            _connection?.Dispose();

            base.Dispose();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            lock (ModelCreationLockObject)
            {
                if (_currentModel != null) optionsBuilder.UseModel(_currentModel);
            }

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            lock (ModelCreationLockObject)
            {
                base.OnModelCreating(modelBuilder);

                // Configuramos el mapping de las tablas
                
                //Entidad
                EntidadConfigurator.Configure(modelBuilder);
                ServicioConfigurator.Configure(modelBuilder);
                ComentarioProductoConfigurator.Configure(modelBuilder);
                ComentarioServicioConfigurator.Configure(modelBuilder);
                ConversacionComentarioProductoConfigurator.Configure(modelBuilder);
                ConversacionComentarioServicioConfigurator.Configure(modelBuilder);
                DiaHorarioDisponibleConfigurator.Configure(modelBuilder);
                DiaSemanaConfigurator.Configure(modelBuilder); 
                LineaProductoConfigurator.Configure(modelBuilder);
                ProductoConfigurator.Configure(modelBuilder);
                ProductoImagenConfigurator.Configure(modelBuilder);
                ServicioImagenConfigurator.Configure(modelBuilder);
                TipoComentorioConfigurator.Configure(modelBuilder);
                TipoEntidadConfigurator.Configure(modelBuilder);
                TipoServicioConfigurator.Configure(modelBuilder);

                //Comun 
                ProvinciaConfigurator.Configure(modelBuilder); 
                BarrioConfigurator.Configure(modelBuilder);
                SexoConfigurator.Configure(modelBuilder);
                TipoVehiculoConfigurator.Configure(modelBuilder);
                LocalidadConfigurator.Configure(modelBuilder);
                 
                //Historia
                HistoriaConfigurator.Configure(modelBuilder);
                ComentarioConfigurator.Configure(modelBuilder);
                ConversacionConfigurator.Configure(modelBuilder);
                ImagenHistoriaConfigurator.Configure(modelBuilder);
                ComentarioImagenConfigurator.Configure(modelBuilder);

                //Sujeto 
                PersonaConfigurator.Configure(modelBuilder);
                DomicilioConfigurator.Configure(modelBuilder);

                //Perdida
                ComentarioPerdidaConfigurator.Configure(modelBuilder);
                ConversacionPerdidaConfigurator.Configure(modelBuilder);
                ImagenComentarioPerdida.Configure(modelBuilder);
                ImagenConversacionPerdida.Configure(modelBuilder);
                ImagenPerdidaConfigurator.Configure(modelBuilder);
                PerdidaConfigurator.Configure(modelBuilder);
                UbicacionPerdidaConfigurator.Configure(modelBuilder);

                //Robo
                MedioAsaltanteConfigurator.Configure(modelBuilder);
                TipoInvolucradoRoboConfigurator.Configure(modelBuilder);
                ObjetoRobadoConfigurator.Configure(modelBuilder);

                foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
                    relationship.DeleteBehavior = DeleteBehavior.Restrict;

                _currentModel = modelBuilder.Model;
            }
        }

        private void UpdateEntityState(object entity, EntityState entityState) //where TEntity : BaseEntity
        {
            //var dbEntityEntry = GetDbEntityEntrySafely(entity);
            //dbEntityEntry.State = entityState;

            var entry = Entry(entity);
            if (entry.State == EntityState.Detached) Attach(entity);

            entry.State = entityState;
        }

    }
}
