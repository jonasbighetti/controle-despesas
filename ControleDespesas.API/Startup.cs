using ControleDespesas.Dominio.Config;
using ControleDespesas.Infra.CrossCutting;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using System.IO;

namespace ControleDespesas.API
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddCors();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                    new Info
                    {
                        Title = "Controle de despesas",
                        Version = "v1",
                        Description = "Projeto de controle de despesas desenvolvido em ASP.Net Core e MongoDB",
                        Contact = new Contact
                        {
                            Name = "Jonas Bighetti",
                            Url = "https://github.com/jonasbighetti"
                        }
                    });

                var filePath = Path.Combine(System.AppContext.BaseDirectory, "ControleDespesas.API.xml");
                c.IncludeXmlComments(filePath);
            });

            services.Configure<DbSettingsConfig>(Configuration);
            Bootstrapper.RegisterServices(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseCors(c =>
            {
                c.AllowAnyHeader();
                c.AllowAnyMethod();
                c.AllowAnyOrigin();
            });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Controle de despesas API");
            });

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
