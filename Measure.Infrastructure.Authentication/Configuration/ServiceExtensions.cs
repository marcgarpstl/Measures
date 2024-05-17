using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Measure.Domain.Services;

namespace Measure.Infrastructure.Authentication.Configuration
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddAuthServices(this IServiceCollection services, IConfigurationSection configuration)
        {
            services.Configure<ManagementToken>(configuration);
            services.AddHttpClient<IAutheticationService, AuthenticationService>();
            services.AddTransient<IAutheticationService, AuthenticationService>();

            return services;
        }
    }
}
