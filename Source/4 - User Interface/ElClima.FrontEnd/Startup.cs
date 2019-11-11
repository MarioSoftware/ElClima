using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using Newtonsoft.Json.Serialization;
using ElClima.FrontEnd.Helpers;
using System;
using ElClima.FrontEnd.Config;
using ElClima.DataAccess;
using Microsoft.EntityFrameworkCore;
using ElClima.Domain.Core.DependencyInjection;
using ElClima.DataAccess.DependencyInjection;
using Microsoft.AspNetCore.Identity;
using ElClima.Authorization;

namespace ElClima.FrontEnd
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IHostingEnvironment environmnet)
        {
            _configuration = configuration;
            _environment = environmnet;
        }

        private readonly IHostingEnvironment _environment;
        private readonly IConfiguration _configuration;

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {

            //services.AddAutoMapper();

            services.AddElClimaPolicies(_environment);

            services.AddMvc(options =>
            {
                // Permite texplo plano en WebApi
                options.InputFormatters.Add(new TextPlainInputFormatter());
            })
               .AddJsonOptions(options
                   => options.SerializerSettings.ContractResolver
                       = new DefaultContractResolver());


            var connectionStringFile = Environment.GetEnvironmentVariable("ELCLIMA_CONN_STRING_FILE");
            if (string.IsNullOrWhiteSpace(connectionStringFile))
                connectionStringFile = "connectionstrings.json";

            var connStringConfig = new ConfigurationBuilder()
                .AddJsonFile(connectionStringFile)
                .Build();


            // Agregamos la configuracion de ElClima 
            services.AddSingleton<ElClimaConfiguration, ElClimaConfiguration>();
            services.Configure<ElClimaConfigurationOptions>(_configuration.GetSection("ElClima"));/*TODO: Search where 'ElClima' it should be seted as Key*/

            // Agregamos dbContext para usar en el dominio
            var connectionString = connStringConfig.GetConnectionString("DefaultConnection");

            services.AddDbContext<ElClimaDbContext>(options =>
            {
                options
                .UseSqlServer(connectionString)
                .EnableSensitiveDataLogging();
            }
            );


            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ElClimaDbContext>()
                .AddDefaultTokenProviders();



            // Registramos el UoW factory para usar en nuestro dominio
            services.AddScoped<IUnitOfWorkFactory, UnitOfWorkFactory>();

            services.ConfigureApplicationServices();

        }
         
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                
            }

            app.UseMiddleware(typeof(ErrorHandlingMiddleware));

            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                // Base page
                routes.MapRoute("default", "{controller=Base}/{action=Index}");
                
                routes.MapRoute("areas", "{area:exists}/{controller=Base}/{action=Index}/{id?}");
            });

        }
    }
}
