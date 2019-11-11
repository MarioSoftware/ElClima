using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace ElClima.Authorization
{
    public static class IServiceCollectionExtension
    {
        public static IServiceCollection AddElClimaPolicies(this IServiceCollection services, IHostingEnvironment environment)
        {
            Configuration.SetPolicies(services, environment.IsDevelopment());

            return services;
        }
    }
}
