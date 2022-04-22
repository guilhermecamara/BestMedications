using AutoMapper;
using Infrastructure.Database;
using Infrastructure.Database.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Presentation.Api.Controllers.Dtos;
using Presentation.Api.IoC;

namespace Presentation.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerDocument();
            Database.ConfigureDatabase(services, Configuration.GetConnectionString("AppDbContext"));
            Container.ConfigureIoC(services);

            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ModelsMappingProfile>();
                cfg.AddProfile<DtosMappingProfile>();                
            });

            IMapper mapper = configuration.CreateMapper();
            services.AddSingleton(mapper);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

            app.UseOpenApi();
            app.UseSwaggerUi3();

            DatabaseMigration.MigrationInitialisation(app);
        }
    }
}