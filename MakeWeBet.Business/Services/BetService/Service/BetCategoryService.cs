using AutoMapper;
using MakeWeBet.Business.Services.BetService.Interface;
using MakeWeBet.Business.Services.Shared.Service;
using MakeWeBet.Business.Services.UnitOfWork;
using MakeWeBet.Data.Enums;
using MakeWeBet.Data.Models.Entity;
using MakeWeBet.Data.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeWeBet.Business.Services.BetService.Service
{
    public class BetCategoryService : BaseEntityService, IBetCategoryService
    {
        public BetCategoryService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {

        }


        public async Task<IEnumerable<BetCategoryViewModel>> GetAllActiveBetCategories()
        {
            IEnumerable<BetCategory> betCategories = await _unitOfWork.GetRepository<BetCategory>()
                .GetListAsync(x => x.EntityStatus == EntityStatus.ACTIVE);

            IEnumerable<BetCategoryViewModel> supportedCountries = _mapper.Map<IEnumerable<BetCategoryViewModel>>(betCategories);

            return supportedCountries;
        }

        public async Task<BetCategory> PostBetCategory(string name)
        {
            BetCategory betCategory = new BetCategory()
            {
                Name = name,
                EntityStatus = EntityStatus.ACTIVE,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };
            _unitOfWork.GetRepository<BetCategory>().Add(betCategory);
            await _unitOfWork.SaveChangesAsync();
            return betCategory;
        }
    }
}
