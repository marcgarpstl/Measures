using Measure.Domain.Repositories;
using Measure.Domain.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Measure.Domain.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddDomainServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            return services;
        }
    }
}
