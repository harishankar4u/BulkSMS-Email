using AutoWrapper;
using InaPlatform.BH.Core.Extensions;
using InaPlatform.BH.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkEmail
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // needed to load configuration from appsettings.json
            services.AddOptions();
            services.AddServicesInAssembly(Configuration, typeof(Startup));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {

            //Enable Swagger and SwaggerUI
            app.UseSwagger(Configuration);

            //E
            app.UseApiResponseAndExceptionWrapper(new AutoWrapperOptions { IsDebug = true, UseApiProblemDetailsException = true });

            //Enable global exception handler
            app.UseCustomExceptionHandler();

            app.UseRouting();
            //Enable CORS
            //app.UseCors("AllowAll");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
