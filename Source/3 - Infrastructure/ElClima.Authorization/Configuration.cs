using ElClima.Domain.Model.Enums.Social.Sujeto;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElClima.Authorization
{
    public static class Configuration
    {
        private static ServiceProvider _serviceProvider;
        private static IServiceCollection ServiceCollection { get; set; }

        internal static T GetService<T>()
        {
            if (_serviceProvider == null)
            {
                _serviceProvider = ServiceCollection.BuildServiceProvider();
            }

            return _serviceProvider.GetService<T>();

        }

        internal static void SetPolicies(IServiceCollection services, bool isDevelopment)
        {
            ServiceCollection = services;

            services.AddAuthorization(options =>
            {
                AddPolicy(isDevelopment, options, OperacionEnum.CommonFunctionsTodo.GetDescription());
                AddPolicy(isDevelopment, options, OperacionEnum.SpecialFunctionsEspecial.GetDescription());
            });
        }

        private static void AddPolicy(bool isDevelopment, AuthorizationOptions options, string operationName)
        {
            options.AddPolicy(operationName,
                policy => policy.RequireAssertion(context =>
                    AuthorizationHelper.CheckForPermission(isDevelopment, context, operationName)));
        }

    }
}
