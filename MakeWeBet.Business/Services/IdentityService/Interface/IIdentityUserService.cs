using MakeWeBet.Data.Enums;
using MakeWeBet.Data.Models.IdentityModel;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MakeWeBet.Business.Services.IdentityService.Interface
{
    public interface IIdentityUserService
    {
        Task<IdentityResult> CreateIdentityUser(ApplicationUser identityUser, SystemRole systemRole, string pin = "default");
        Task<ApplicationUser> GetApplicationUserAsync(string identityUserId);
        Task<IdentityResult> UpdateIdentityUser(ApplicationUser identityUser);
        Task<ApplicationUser> GetApplicationUser(ClaimsPrincipal claimsPrincipal);
        Task<string> GetUserId(ClaimsPrincipal claimsPrincipal);
    }
}
