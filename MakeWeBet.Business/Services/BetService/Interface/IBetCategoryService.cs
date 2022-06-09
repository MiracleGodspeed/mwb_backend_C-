using MakeWeBet.Data.Models.Entity;
using MakeWeBet.Data.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeWeBet.Business.Services.BetService.Interface
{
    public interface IBetCategoryService
    {
        Task<IEnumerable<BetCategoryViewModel>> GetAllActiveBetCategories();
        Task<BetCategory> PostBetCategory(string name);
    }
}
