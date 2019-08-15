using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElClima.Domain.Core.DependencyInjection
{
    public static class ServiceCollectionExtension
    {
        public static void ConfigureApplicationServices(this IServiceCollection services)
        {
            ServiceReference.ServiceCollection = services;
        }
    }
}
