using MakeWeBet.Business.Services.BetService.Interface;
using MakeWeBet.Data.Enums;
using MakeWeBet.Data.Models.Entity;
using MakeWeBet.Data.Models.Response;
using MakeWeBet.Data.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace MakeWeBet.APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BetCategoryController : BaseController
    {
        private readonly IBetCategoryService _betCategoryService;

        public BetCategoryController(IBetCategoryService betCategoryService)
        {
            _betCategoryService = betCategoryService;
        }

        [HttpGet("[action]")]
        [ProducesResponseType(typeof(IEnumerable<BetCategoryViewModel>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorDetails), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> ActiveCategories()
        {
            IEnumerable<BetCategoryViewModel> response = await _betCategoryService.GetAllActiveBetCategories();
            return OkBase(response);
        }

        [HttpPost("[action]")]
        [ProducesResponseType(typeof(ApiResponseModel<BetCategory>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorDetails), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> CreateCategory(string BetCategoryName)
        {
                BetCategory response = await _betCategoryService.PostBetCategory(BetCategoryName);
                if (response != null)
                {
                    return Ok(response.Id, "Bet Category added!", ResponseStatus.OK);
                }
            return null;
        }
    }
}
