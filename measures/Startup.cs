using Measure.Domain.Extensions;
using Measure.Infrastructure.Extensions;

namespace Measures
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddDomainServices();
            services.AddInfrastructureServices();
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
