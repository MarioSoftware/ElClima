using ElClima.Domain.Core.Repository;
using Microsoft.Extensions.DependencyInjection; 

namespace ElClima.Domain.Core.DependencyInjection
{
    public interface IUnitOfWorkFactory
    {
        IUnitOfWork GetNewUnitOfWork(ServiceProvider provider);
    }
}
