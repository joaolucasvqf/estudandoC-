using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MimicAPI.Database;
using MimicAPI.V1.Repositories;
using MimicAPI.V1.Repositories.Contracts;
using AutoMapper;
using MimicAPI.Helpers;
using System.Linq;
using System;

namespace MimicAPI
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
            #region AutoMapper-Config
            var config = new MapperConfiguration(cfg => {
                cfg.AddProfile(new DTOMapperProfile());
            });
            IMapper mapper = config.CreateMapper();
            services.AddSingleton(mapper);
            #endregion

            services.AddDbContext<MimicContext>(opt =>
            {
                opt.UseSqlite("Data Source=Database\\Mimic.db");
            });
            services.AddMvc();
            services.AddScoped<IPalavraRepository, PalavraRepository>();
            services.AddApiVersioning(cfg => {
                cfg.ReportApiVersions = true;
                //Seletor de versão pelos headers da request
                //cfg.ApiVersionReader = new HeaderApiVersionReader("api-version");
                cfg.AssumeDefaultVersionWhenUnspecified = true;
                cfg.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(1, 0);
            });
            services.AddSwaggerGen(cfg =>
            {
                cfg.ResolveConflictingActions(apiDescription => apiDescription.First());
                cfg.SwaggerDoc("v1", new Swashbuckle.AspNetCore.Swagger.Info()
                {
                    Title = "MimicAPI - V1",
                    Version = "v1"
                });
            });
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

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger(); // /swagger/v1/swagger.json
            app.UseSwaggerUI(cfg => {
                cfg.SwaggerEndpoint("/swagger/v1.0/swagger.json", "MimicAPI - V1.0");
                cfg.RoutePrefix = String.Empty;
            });
        }
    }
}
