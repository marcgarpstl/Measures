using Measure.Domain.Extensions;
using Measure.Infrastructure.Context;
using Measure.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Identity.Client;

namespace Measures
{
    public class Startup
    {
        private readonly IConfiguration _configuration;
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        
        public void ConfigureServices(IServiceCollection services)
        {
            string connectionString = _configuration.GetConnectionString("DefaultConnection");
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
