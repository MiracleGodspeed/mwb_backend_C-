using MakeWeBet.Business.Interface;
using MakeWeBet.Business.Services.Shared;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeWeBet.Business.Infrastructure.StartupExtension
{
    public static class ServiceExtension
    {
        public static void ConfigureService(this IServiceCollection services)
        {
            //services.AddScoped<ILoggerManager, LoggerManager>();
            services.AddSingleton<ILoggerManager, LoggerManager>();
        }

    }
}
