using MakeWeBet.Data.Models.Entity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeWeBet.Data.Models.IdentityModel
{
  
        public class ApplicationUser : IdentityUser
        {
            public Guid? CountryCallingCodeId { get; set; }
            public string RefreshToken { get; set; }
    }
}
