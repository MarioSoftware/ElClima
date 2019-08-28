using ElClima.DataAccess.ConcreteRepository;
using ElClima.Domain.Core.DependencyInjection;
using ElClima.Domain.Core.Repository;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElClima.DataAccess.DependencyInjection
{
    public class UnitOfWorkFactory : IUnitOfWorkFactory
    {
        public IUnitOfWork GetNewUnitOfWork(ServiceProvider provider)
        {


            // Con esto se crea una nueva instancia:
            var scope = provider.CreateScope();
            var context = scope.ServiceProvider.GetService<ElClimaDbContext>();

            //
            // Con esto se hace que si no se pasa la uow en el contructor del service se cree un nuevo context en cada instancia             


            //var context = provider.GetService<SimonMipsDbContext>();

            return new UnitOfWork(context);
        }
    }
}
