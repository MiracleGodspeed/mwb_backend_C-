using MakeWeBet.Business.Services.UserAccountService.Interface;
using MakeWeBet.Data.Enums;
using MakeWeBet.Data.Models.DTOs;
using MakeWeBet.Data.Models.Entity;
using MakeWeBet.Data.Models.Response;
using MakeWeBet.Data.Models.ServiceModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace MakeWeBet.APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : BaseController
    {
        private readonly IUserAccountService _accountService;
        private readonly IWebHostEnvironment _webHostingEnvironment;


        public AccountController(IUserAccountService accountService, IWebHostEnvironment webHostEnvironment)
        {
            _accountService = accountService;
            _webHostingEnvironment = webHostEnvironment;
        }

        [AllowAnonymous]
        [HttpPost("[action]")]
        [ProducesResponseType(typeof(ApiResponseModel<Jwt>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorDetails), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Signup([FromBody] SignupDto signupRequest)
        {
            if (!string.IsNullOrEmpty(signupRequest.Username) && !string.IsNullOrEmpty(signupRequest.Password))
            {
                User authReponse = await _accountService.CreateUserAccount(signupRequest);
                if (authReponse != null)
                {
                    return Ok(authReponse.Id, "Account was created successfully", ResponseStatus.OK);
                }
            }
            return NotFound("User not found");

        }
    }
}
