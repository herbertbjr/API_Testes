using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System.Text.Json;
using Newtonsoft.Json;
using ProjetoTeste.Context;
using ProjetoTeste.Repository;
using AutoMapper;

namespace ProjetoTeste
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
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            // swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "API|Contratos",
                    Description = "Base de Contratos e Prestações",
                    TermsOfService = new Uri("https://api/contratos/terms"),
                    Contact = new OpenApiContact
                    {
                        Name = "Herbert Bruchmann Junior",
                        Email = "hbrjunior@outlook.com",
                        Url = new Uri("https://api/contratos/author"),
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Usar sobre LICX",
                        Url = new Uri("https://api/contratos/license"),
                    }
                });
            });

            services.AddControllers()
                .AddNewtonsoftJson();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseCors(opt => opt.AllowAnyOrigin());

            // swagger
            app.UseSwagger();

            // swaggerUI
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json",
                    "APIContratos");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
