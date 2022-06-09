using AutoMapper;
using MakeWeBet.Business.Infrastructure.Exceptions;
using MakeWeBet.Business.Interface;
using MakeWeBet.Business.Services.IdentityService.Interface;
using MakeWeBet.Business.Services.Shared.Interface;
using MakeWeBet.Business.Services.Shared.Service;
using MakeWeBet.Business.Services.UnitOfWork;
using MakeWeBet.Business.Services.UserAccountService.Interface;
using MakeWeBet.Data.Enums;
using MakeWeBet.Data.Models.DTOs;
using MakeWeBet.Data.Models.Entity;
using MakeWeBet.Data.Models.IdentityModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeWeBet.Business.Services.UserAccountService.Service
{
    public class UserAccountService : BaseEntityService, IUserAccountService
    {
        private readonly UserManager<ApplicationUser> UserManager;
        private readonly ILoggerManager LoggerManager;
        private readonly IServiceFactory ServiceFactory;
        public UserAccountService(UserManager<ApplicationUser> userManager,
          ILoggerManager loggerManager,
          IServiceFactory serviceFactory,
          IMapper mapper,
          IUnitOfWork unitOfWork) : base(unitOfWork, mapper)
        {
            LoggerManager = loggerManager;
            UserManager = userManager;
            ServiceFactory = serviceFactory;
        }
        public async Task<User> CreateUserAccount(SignupDto signupRequest)
        {
            IIdentityUserService identityUserService = ServiceFactory.GetService(typeof(IIdentityUserService)) as IIdentityUserService;
            

            User mwbUser = await _unitOfWork.GetRepository<User>()
                .FirstOrDefaultAsync(p => p.Username == signupRequest.Username, include: x => x.Include(y => y.Currency));

            if (mwbUser != null)
                throw new InvalidOperationException("A User Already Exists With That Tag Name");

            ApplicationUser identityUser = new ApplicationUser()
            {
                Email = signupRequest.Email,
                UserName = signupRequest.Username,
                PhoneNumber = signupRequest.PhoneNumber,
                EmailConfirmed = false,
                PhoneNumberConfirmed = false
            };

            IdentityResult result = await identityUserService.CreateIdentityUser(identityUser, SystemRole.User, signupRequest.Password);
            if (result.Succeeded)
            {
                mwbUser = new User()
                {
                    Username = signupRequest.Username,
                    Role = SystemRole.User
                };
                mwbUser = _unitOfWork.GetRepository<User>().Add(mwbUser);
                int recordCount = await _unitOfWork.SaveChangesAsync();

                if (recordCount > 0)
                {
                    return mwbUser;
                }
                else
                {
                    throw new AppException("Could Not Complete Registration Process");
                }
            }
            else
            {
                LoggerManager.LogError($"Could not create identity user during account creation  [CreateUserDetails] | {JsonConvert.SerializeObject(result)}");
                throw new InvalidOperationException("Could Not Complete Signup Process");
            }

        }

    }
}
