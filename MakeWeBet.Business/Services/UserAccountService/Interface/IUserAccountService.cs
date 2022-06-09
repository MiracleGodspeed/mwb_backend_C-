using MakeWeBet.Data.Models.DTOs;
using MakeWeBet.Data.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeWeBet.Business.Services.UserAccountService.Interface
{
    public interface IUserAccountService
    {
        Task<User> CreateUserAccount(SignupDto signupRequest);
    }
}
