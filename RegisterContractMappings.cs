using InaPlatform.BH.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkEmail
{
    public class RegisterContractMappings: IServiceRegistration
    {
        public void RegisterAppServices(IServiceCollection services, IConfiguration config)
        {
            //Register Interface Mappings for Repositories

            services.AddHostedService<EmailNotifier>();
            services.AddTransient<IProcessEmail, ProcessEmail>();
            services.AddTransient<IHttpWrapper, HttpWrapper>();
        }
    }
}
