using Measure.Domain.Extensions;
using Measure.Infrastructure.Authentication.Configuration;
using Measure.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Configuration;



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
            services.AddCors();
            services.AddAuthServices(_configuration.GetSection(nameof(ManagementToken)));

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

            app.UseCors(builder =>
            {
                builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .WithHeaders("Authorization", "Content-Type");
            });

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
