using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MakeWeBet.Business.Infrastructure.StartupExtension
{
    public static class SwaggerConfiguration
    {
     
        public static IServiceCollection RegisterAndConfigureSwaggerAuthorizationOptions(this IServiceCollection services)
        {
            services.AddSwaggerGen(s =>
            {

                s.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "MWB.WebApi",
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
            return services;
        }

        private static string GetXmlCommentsPath()
        {
            string xmlFileName = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            string filePath = Path.Combine(AppContext.BaseDirectory, xmlFileName);
            return filePath;
        }

    }
}
