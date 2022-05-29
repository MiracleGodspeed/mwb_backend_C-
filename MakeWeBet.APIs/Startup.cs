using MakeWeBet.Business.Infrastructure.Exceptions;
using MakeWeBet.Business.Infrastructure.StartupExtension;
using MakeWeBet.Business.Interface;
using MakeWeBet.Business.Middleware;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MakeWeBet.APIs
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
            //services.AddDbContext<PayPlatContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("PayPlatConnectionstring"),
            //                                sqlServerOptionsAction: sqlOptions => {
            //                                    sqlOptions.EnableRetryOnFailure(
            //                                                maxRetryCount: 3,
            //                                                maxRetryDelay: TimeSpan.FromSeconds(30),
            //                                                errorNumbersToAdd: null);
            //                                }).EnableSensitiveDataLogging()
            //                               , ServiceLifetime.Transient
            //                             );
            services.AddControllers();
            services.RegisterAndConfigureSwaggerAuthorizationOptions();
            services.ConfigureService();
            services.AddAuthentication();
            services.AddHealthChecks();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerManager loggerManager)
        {
            app.UseStaticFiles();
            //app.UseStaticFiles(new StaticFileOptions
            //{
            //    FileProvider = new PhysicalFileProvider(
            //       Path.Combine(Directory.GetCurrentDirectory(), @"Resources")),
            //    RequestPath = "/Resources"

            //});
            // custom jwt auth middleware
            app.UseMiddleware<JWTMiddleware>();
            // Custom Error Handling Middleware
            //app.UseMiddleware<ErrorHandlerMiddleware>();
            app.UseMiddleware(typeof(ErrorHandlerMiddleWare));
            if (!env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("../swagger/v1/swagger.json", "MakeWeBet.Api v1"));

            //app.ConfigureExceptionHandler(loggerManager, env);

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
