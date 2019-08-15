using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElClima.Domain.Core.DependencyInjection
{
    public static class ServiceReference
    {
        internal static IServiceCollection ServiceCollection { private get; set; }

        private static ServiceProvider _serviceProvider;

        public static ServiceProvider GetServiceProvider()
        {
            if (_serviceProvider == null)
            {
                _serviceProvider = ServiceCollection.BuildServiceProvider();
            }
            return _serviceProvider;
        }

        public static T GetService<T>()
        {
            return GetServiceProvider().GetService<T>();
        }
    }
}
