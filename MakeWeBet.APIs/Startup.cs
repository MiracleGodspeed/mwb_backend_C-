using MakeWeBet.Business.Infrastructure.Exceptions;
using MakeWeBet.Business.Infrastructure.ServiceExtension;
using MakeWeBet.Business.Infrastructure.StartupExtension;
using MakeWeBet.Business.Interface;
using MakeWeBet.Business.Middleware;
using MakeWeBet.Data.Models.Context;
using MakeWeBet.Data.Models.IdentityModel;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            services.AddControllers();
            services.ConfigureCors();
            //      services.AddDbContext<IdentityDatabaseContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("MWBConnectionstring"),
            //                                           sqlServerOptionsAction: sqlOptions => {
            //                                               sqlOptions.EnableRetryOnFailure(
            //                                                           maxRetryCount: 3,
            //                                                           maxRetryDelay: TimeSpan.FromSeconds(30),
            //                                                           errorNumbersToAdd: null);
            //                                           }).EnableSensitiveDataLogging()
            //                                          , ServiceLifetime.Transient
            //);
            string connectionString = Configuration.GetConnectionString("MWBConnectionstring");

            //services.AddDbContext<MakeWeBetContext>(options =>
            //{
            //    options.UseSqlServer(Configuration.GetConnectionString("MWBConnectionstring"),
            //    sqlServerOptionsAction: sqlOptions =>
            //    {
            //        sqlOptions.EnableRetryOnFailure();
            //    }).UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            //}, ServiceLifetime.Transient);

      
            //services.ConfigureDatabaseConnection(connectionString);
           
            //services.AddDbContext<MakeWeBetContext>(options =>
            //{
            //    options.UseSqlServer(Configuration.GetConnectionString("MWBConnectionstring"),
            //    sqlServerOptionsAction: sqlOptions =>
            //    {
            //        sqlOptions.EnableRetryOnFailure();
            //    }).UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            //}, ServiceLifetime.Transient);
            services.AddDbContext<MakeWeBetContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("MWBConnectionstring"),
                                           sqlServerOptionsAction: sqlOptions =>
                                           {
                                               sqlOptions.EnableRetryOnFailure(
                                                           maxRetryCount: 3,
                                                           maxRetryDelay: TimeSpan.FromSeconds(30),
                                                           errorNumbersToAdd: null);
                                           }).EnableSensitiveDataLogging()
                                          , ServiceLifetime.Transient
);
            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.Password.RequiredLength = 0;
                options.Password.RequiredUniqueChars = 0;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireDigit = false;

                //Lockout settings.
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
                options.Lockout.MaxFailedAccessAttempts = 3;
                options.Lockout.AllowedForNewUsers = true;

                options.SignIn.RequireConfirmedPhoneNumber = false;
                options.SignIn.RequireConfirmedEmail = true;
                options.User.RequireUniqueEmail = true;
            }).AddEntityFrameworkStores<MakeWeBetContext>().AddDefaultTokenProviders();
            //services.ConfigureService();
            //services.ConfigureIdentityProvider(Configuration);
            //services.ConfigureSwagger();
            services.ConfigureJWT(Configuration);
            services.ConfigureEmailService(Configuration);
            services.RegisterAndConfigureSwaggerAuthorizationOptions();
            services.ConfigureService();
            services.AddAuthentication();
            services.AddHealthChecks();
            services.AddHttpClient();
           

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerManager loggerManager, MakeWeBetContext makeWeBetContext, RoleManager<IdentityRole> roleManager)
        {

            //Remove in production!!!!
            UpdateDatabase(app);
            app.UseStaticFiles();
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(
                   Path.Combine(Directory.GetCurrentDirectory(), @"Resources")),
                RequestPath = "/Resources"

            });
            Task.Run(() => SecurityConfigurationRegistry.CreateApplicationRoles(roleManager)).Wait();
            // custom jwt auth middleware
            app.UseMiddleware<JWTMiddleware>();
            // Custom Error Handling Middleware
            //app.UseMiddleware<ErrorHandlerMiddleware>();
            app.UseMiddleware(typeof(ErrorHandlerMiddleWare));
            if (!env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseSwagger();

            //app.UseSwaggerUI(c =>
            //{
            //    string swaggerJsonBasePath = string.IsNullOrWhiteSpace(c.RoutePrefix) ? "." : "..";
            //    c.SwaggerEndpoint($"/swagger/v1/swagger.json", "XendBridge API");
            //    c.RoutePrefix = "api-docs/internal";
            //})
            // .UseReDoc(c =>
            // {
            //     string swaggerJsonBasePath = string.IsNullOrWhiteSpace(c.RoutePrefix) ? "." : "..";
            //     c.SpecUrl($"/swagger/v1/swagger.json");
            //     c.DocumentTitle = "XendBridge API";
            //     c.RoutePrefix = "api-docs/redoc";
            // });
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("../swagger/v1/swagger.json", "MakeWeBet.Api v1"));

            //app.ConfigureExceptionHandler(loggerManager, env);

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors(x => x
                .SetIsOriginAllowed(origin => true)
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials());
            //app.UseCors("CorsPolicy");
            //app.ConfigureExceptionHandler(loggerManager, env);
            //app.UseMiddleware<RequestLogHandler>(loggerManager);

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }


        private static void UpdateDatabase(IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices
                .GetRequiredService<IServiceScopeFactory>()
                .CreateScope();
            using var context = serviceScope.ServiceProvider.GetService<MakeWeBetContext>();
            context.Database.Migrate();


        }
    }
}
