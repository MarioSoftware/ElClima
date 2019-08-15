using Microsoft.Extensions.DependencyInjection; 

namespace ElClima.Domain.Core.DependencyInjection
{
    public interface IUnitOfWorkFactory
    {
        IUnitOfWorkFactory GetNewUnitOfWork(ServiceProvider provider);
    }
}
