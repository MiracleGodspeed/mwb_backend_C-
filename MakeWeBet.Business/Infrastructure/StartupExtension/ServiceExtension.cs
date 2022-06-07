using MakeWeBet.Business.Interface;
using MakeWeBet.Business.Services.IdentityService.Interface;
using MakeWeBet.Business.Services.IdentityService.Services;
using MakeWeBet.Business.Services.Shared;
using MakeWeBet.Data.Models.Context;
using MakeWeBet.Data.Models.IdentityModel;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeWeBet.Business.Infrastructure.StartupExtension
{
    public static class ServiceExtension
    {
        public static void ConfigureJWT(this IServiceCollection services, IConfiguration configuration)
        {
            
            byte[] key = Encoding.ASCII.GetBytes(configuration["Jwt:Key"]);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
        }
        public static IServiceCollection ConfigureDatabaseConnection(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<IdentityDatabaseContext>(options =>
               options.UseSqlServer(
                   connectionString, b => b.MigrationsAssembly("MakeWeBet")));

            services.AddDbContext<MakeWeBetContext>(options =>
            {
                options.UseSqlServer(connectionString, b => b.MigrationsAssembly("MakeWeBet"))
                .ConfigureWarnings(c => c.Log(CoreEventId.DetachedLazyLoadingWarning, CoreEventId.LazyLoadOnDisposedContextWarning));

            });
            return services;
        }
        public static void ConfigureEmailService(this IServiceCollection services, IConfiguration Configuration)
        {
            services
                .AddFluentEmail("support@makewebet.com")
                .AddMailGunSender(
                    Configuration.GetValue<string>("MailGun:domain"),
                    Configuration.GetValue<string>("MailGun:apiKey"),
                    FluentEmail.Mailgun.MailGunRegion.EU
                    )
                .AddRazorRenderer();
        }

        public static void ConfigureSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(s =>
            {

                s.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "MakeWeBet.Api",
                    Version = "v1",
                    Description = "P2P Bet Solution",
                    Contact = new OpenApiContact
                    {
                        Name = "Godspeed Miracle",
                        Email = "miracleoghenemado@gmail.com"
                    }
                });

                var securityScheme = new OpenApiSecurityScheme
                {
                    Name = "JWT Authentication",
                    Description = "Enter JWT Bearer token **_only_**",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer", // must be lower case
                    BearerFormat = "JWT",
                    Reference = new OpenApiReference
                    {
                        Id = JwtBearerDefaults.AuthenticationScheme,
                        Type = ReferenceType.SecurityScheme
                    }
                };

                s.AddSecurityDefinition(securityScheme.Reference.Id, securityScheme);
                s.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {securityScheme, new string[] { }}
                });


                s.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());

            });
        }

        public static void ConfigureService(this IServiceCollection services)
        {
            //services.AddScoped<ILoggerManager, LoggerManager>();

            services.AddSingleton<ILoggerManager, LoggerManager>();


            //Identity Services
            services.TryAddScoped<UserManager<ApplicationUser>>();
            services.AddTransient<IIdentityUserService, IdentityUserService>();
        }


        public static void ConfigureCors(this IServiceCollection services) =>
      services.AddCors(options =>
      {
          options.AddPolicy("CorsPolicy", builder =>
          builder.AllowAnyOrigin()
          .AllowAnyMethod()
          .AllowAnyHeader()
          .WithExposedHeaders("*") // params string[]
          );
      });

    }
}
