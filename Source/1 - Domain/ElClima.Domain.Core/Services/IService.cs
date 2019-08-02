using ElClima.Domain.Core.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElClima.Domain.Core.Services
{
    public interface IService : IDisposable
    {
        IUnitOfWork GetCurrentUnitOfWork();
    }
}
