using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using FonotradeInvoiceControl.BLL;
using FonotradeInvoiceControl.BLL.Interfaces;
using FonotradeInvoiceControl.VHSYS.Services;
using FonotradeInvoiceControl.VHSYS.Services.Interfaces;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.IO;
using System;
using FonotradeInvoiceControl.Middleware;
using FonotradeInvoiceControl.Utils;

namespace FonotradeInvoiceControl
{
    public class Startup
    {
        public IConfiguration Configuration { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            SetConfig(services);

            DependencyInjector.InjectCommonDependencies(services);
            ConfigureClients(services);
            services.AddControllers();
            services.AddSwaggerGen();
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Fonotrade Invoice Control API",
                    Description = "API de controle para as notas fiscais da Fonotrade"
                });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                options.IncludeXmlComments(xmlPath);
            });
        }

        public virtual void SetConfig(IServiceCollection services)
        {
            var configurationBuilder = new ConfigurationBuilder()
                            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                            .AddEnvironmentVariables();

            Configuration = configurationBuilder.Build();

            services.AddSingleton<IConfiguration>(provider => Configuration);


        }

        public virtual void ConfigureClients(IServiceCollection services)
        {
            services.AddScoped<IVHSYSService, VHSYSService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Fonotrade Invoice Control API");
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();
            app.UseMiddleware<ErrorHandlerMiddleware>();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
