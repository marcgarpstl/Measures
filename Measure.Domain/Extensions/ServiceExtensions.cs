using Measure.Domain.Repositories;
using Measure.Domain.Services;
using Measure.Domain.Validators;
using Measures.Validators;
using Microsoft.Extensions.DependencyInjection;

namespace Measure.Domain.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddDomainServices(this IServiceCollection services)
        {
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IFemaleMeasureService, FemaleMeasureService>();
            services.AddTransient<IUserValidator, UserValidator>();
            services.AddTransient<ITokenHandlerService, TokenHandlerService>();
            return services;
        }
    }
}
