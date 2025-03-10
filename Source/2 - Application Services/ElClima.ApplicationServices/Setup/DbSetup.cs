﻿using Microsoft.Extensions.DependencyInjection;
using ElClima.Domain.Core.Repository;  
using ElClima.Domain.Core.DependencyInjection;
using ElClima.ApplicationServices.Setup.Common;
using ElClima.ApplicationServices.Setup.Social.Entidad;
using ElClima.ApplicationServices.Setup.Social.Reporte.Robo;
using ElClima.ApplicationServices.Setup.Social.Sujeto;

namespace ElClima.ApplicationServices.Setup
{
    public partial class DbSetup
    {
        private readonly IUnitOfWork _uow;
        private readonly IUnitOfWork UnitOfWork;

        public DbSetup()
        {
            var serviceProvider = ServiceReference.GetServiceProvider();

            _uow = serviceProvider.GetService<IUnitOfWorkFactory>().GetNewUnitOfWork(serviceProvider);

        }

        public void InitializeDatabase()
        {
            //Common
            SexoInitializator.Initialize(_uow);
            TipoVehiculoInitializator.Initialize(_uow);
            ProvinciasLocalidadesInitializator.Initialize(_uow);
            ContactoTipoInitializator.Initialize(_uow);

            //Entidad
            DiaSemanaInitializator.Initialize(_uow);
            TipoComentarioIntializator.Initialize(_uow);
            TipoEntidadIntializator.Initialize(_uow);
            TipoServicioIntializator.Initialize(_uow);

            //Robo
            MedioAsaltanteInitializator.Initialize(_uow);
            TipoInvolucradoRobInitializator.Initialize(_uow);
            ObjetoRobadoInitializator.Initialize(_uow);

            //Sujeto
            RolInitializator.Initialize(_uow);
            OperacionInitializator.Initialize(_uow); 

        }

    }
}
