using AutoMapper;
using MakeWeBet.Data.Models.Entity;
using MakeWeBet.Data.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeWeBet.Data.Models
{
    public  class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<BetCategory, BetCategoryViewModel>();
        }

        private double ConvertToTimeStamp(DateTime dateInstance)
        {
            DateTime epochDateTime = new DateTime(1970, 1, 1);
            return (dateInstance - epochDateTime).TotalMilliseconds;
        }
    }
}
