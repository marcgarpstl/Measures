using Measure.Domain.Repositories;
using Measure.Domain.Services;
using Measure.Infrastructure.Context;
using Measure.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Measure.Infrastructure.Extensions
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<IUserDbContext, UserDbContext>(options => options.UseSqlServer(connectionString));
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IFemaleMeasureRepository, FemaleMeasureRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            return services;
        }
    }
}
