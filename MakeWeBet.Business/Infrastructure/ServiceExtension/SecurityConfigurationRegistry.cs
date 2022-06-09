using MakeWeBet.Data.Enums;
using MakeWeBet.Data.Models.Context;
using MakeWeBet.Data.Models.IdentityModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeWeBet.Business.Infrastructure.ServiceExtension
{
    public static class SecurityConfigurationRegistry
    {
        public static IServiceCollection ConfigureIdentityProvider(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDefaultIdentity<ApplicationUser>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<MakeWeBetContext>()
                //.AddEntityFrameworkStores<IdentityDatabaseContext>()
                .AddDefaultTokenProviders();

            //CommonConfig lockoutConfig = configuration.GetSection("CommonConfig").Get<CommonConfig>();

            services.Configure<IdentityOptions>(config =>
            {
                // User defined password policy settings.  
                config.SignIn.RequireConfirmedEmail = false;

                // Password settings
                config.Password.RequireDigit = false;
                config.Password.RequiredLength = 4;
                config.Password.RequireNonAlphanumeric = false;
                config.Password.RequireUppercase = false;
                config.Password.RequireLowercase = false;
                config.Password.RequiredUniqueChars = 1;

                // Lockout settings
                //config.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(lockoutConfig.FailedLoginLockoutDurationInMinutes);
                //config.Lockout.MaxFailedAccessAttempts = lockoutConfig.MaxFailedLoginAttemptCount;
                config.Lockout.AllowedForNewUsers = true;
                // User settings
                config.User.RequireUniqueEmail = true;

            });


            //services.AddAuthorization(options =>
            //{
            //    options.AddPolicy("IsLoggedInAsUser", policy => policy.RequireClaim("LoggedInAs", "User"));
            //    options.AddPolicy("IsLoggedInAsProvider", policy => policy.RequireClaim("LoggedInAs", "Provider"));
            //    options.AddPolicy("IsLoggedInAsAdmin", policy => policy.RequireClaim("LoggedInAs", "Admin"));
            //    options.AddPolicy("IsLoggedInAsAdmin", policy => policy.RequireClaim("LoggedInAs", "SuperAdmin"));
            //    options.AddPolicy("IsLoggedInAsSupport", policy => policy.RequireClaim("LoggedInAs", "Support"));

            //});

            return services;
        }



        public static async Task CreateApplicationRoles(RoleManager<IdentityRole> roleManager)
        {
            List<string> appRoles = Enum.GetNames(typeof(SystemRole)).ToList();
            foreach (string role in appRoles)
            {
                bool roleExists = await roleManager.RoleExistsAsync(role);
                if (!roleExists)
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
            }
        }
    }
}
