using ElClima.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElClima.Domain.Core.Services
{
    interface IService<TEntity> : IService where TEntity : BaseEntity 
    {
    }
}
