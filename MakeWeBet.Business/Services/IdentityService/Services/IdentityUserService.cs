using MakeWeBet.Business.Services.IdentityService.Interface;
using MakeWeBet.Data.Enums;
using MakeWeBet.Data.Models.ExceptionModels;
using MakeWeBet.Data.Models.IdentityModel;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MakeWeBet.Business.Services.IdentityService.Services
{
    public class IdentityUserService : IIdentityUserService
    {
        private readonly UserManager<ApplicationUser> UserManager;
        //private readonly AppRoleConfig AppRoleConfig;

        public IdentityUserService(UserManager<ApplicationUser> userManager)
        {
            UserManager = userManager;
            //AppRoleConfig = appRoleConfig.Value;
        }

        public async Task<IdentityResult> CreateIdentityUser(ApplicationUser identityUser, SystemRole systemRole, string pin = "default")
        {
            //string userRole = ValidateUserRole(personType);

            IdentityResult result = await UserManager.CreateAsync(identityUser, pin);
            if (!result.Succeeded)
            {
                string errorMessage = HandleIdentityErrors(result.Errors);
                throw new InvalidOperationException(errorMessage);
            }

            await UserManager.AddClaimAsync(identityUser, new Claim(ClaimTypes.Email, identityUser.Email));

            await UserManager.AddToRoleAsync(identityUser, systemRole.ToString());
            return result;
        }


        private string HandleIdentityErrors(IEnumerable<IdentityError> identityErrors)
        {
            string errorMessage = "";

            foreach (var error in identityErrors)
            {
                errorMessage += $"{error.Description}. ";
            }
            return errorMessage;
        }

        public async Task<ApplicationUser> GetApplicationUserAsync(string identityUserId)
        {
            ApplicationUser applicationUser = await UserManager.FindByIdAsync(identityUserId);
            return applicationUser;
        }

        public async Task<IdentityResult> UpdateIdentityUser(ApplicationUser identityUser)
        {
            IdentityResult IdentityResult = await UserManager.UpdateAsync(identityUser);
            return IdentityResult;
        }

        public async Task<string> GetUserId(ClaimsPrincipal claimsPrincipal)
        {
            ApplicationUser user = await GetApplicationUser(claimsPrincipal);
            return user.Id;
        }

        public async Task<ApplicationUser> GetApplicationUser(ClaimsPrincipal claimsPrincipal)
        {
            string identityUserId = UserManager.GetUserId(claimsPrincipal);
            ApplicationUser user = await UserManager.GetUserAsync(claimsPrincipal);
            if (user == null)
                throw new NotFoundException("User Not Found");

            return user;
        }
    }

}
