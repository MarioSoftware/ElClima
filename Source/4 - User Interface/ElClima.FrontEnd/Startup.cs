using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using Newtonsoft.Json.Serialization;
using ElClima.FrontEnd.Helpers;

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

            services.AddMvc(options =>
            {
                // Permite texplo plano en WebApi
                options.InputFormatters.Add(new TextPlainInputFormatter());
            })
               .AddJsonOptions(options
                   => options.SerializerSettings.ContractResolver
                       = new DefaultContractResolver());
        }
         
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                
            }

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
