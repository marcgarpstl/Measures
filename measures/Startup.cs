using Measure.Domain.Extensions;
using Measure.Infrastructure.Context;
using Measure.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Identity.Client;

namespace Measures
{
    public class Startup
    {
        string connectionString = Environment.GetEnvironmentVariable("ConnectionString");
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddDomainServices();
            services.AddInfrastructureServices(connectionString);
        }
        public void Configure(IApplicationBuilder app, IHostEnvironment host) 
        {
            if (host.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Measure.WepApi");
                });
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
